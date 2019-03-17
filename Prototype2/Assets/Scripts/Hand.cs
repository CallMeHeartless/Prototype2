using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    // Actions
    [SerializeField]
    private SteamVR_Action_Boolean grabAction = null;
    [SerializeField]
    private SteamVR_Action_Boolean teleportAction = null;
    [SerializeField]
    private SteamVR_Action_Vector2 touchpadButtons = null;
    [SerializeField]
    private SteamVR_Action_Boolean gripTest = null;

    // Hand variables
    private SteamVR_Behaviour_Pose handPose = null;
    private FixedJoint grabJoint = null;
    [SerializeField]
    private float angularVelocityModifier = 3.0f;
    private static int mulliganCount = 3;

    // Held object
    private Interactable heldObject = null;
    private List<Interactable> interactables = new List<Interactable>();

    // Teleport
    [SerializeField]
    private GameObject teleportPrefab = null;
    private GameObject teleportMarkerInstance = null;
    private bool isTeleporting = false;
    private static bool handsAreFree = true;
    private bool teleportDown = false;
    [SerializeField]
    private float teleportDelay = 0.5f;

    // UI
    [SerializeField]
    private GameObject scoreUI;

    private void Awake() {
        handPose = GetComponent<SteamVR_Behaviour_Pose>();
        if (!handPose) {
            Debug.LogError("ERROR: Hand is missing behaviour pose");
        }
        grabJoint = GetComponent<FixedJoint>();
        if (!grabJoint) {
            Debug.LogError("ERROR: Hand is missing a fixed joint");
        }

        teleportMarkerInstance = Instantiate(teleportPrefab);
        teleportMarkerInstance.transform.position = transform.root.transform.position;
        teleportMarkerInstance.SetActive(false);
        scoreUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        // Picking up and releasing items
        if (grabAction.GetLastStateDown(handPose.inputSource)) {
            Pickup();
        }

        if (grabAction.GetLastStateUp(handPose.inputSource)) {
            Drop();
        }

        // Detect button down
        if (teleportAction.GetLastStateDown(handPose.inputSource)) {

            int specialAction = ConvertTouchPadButtons(touchpadButtons.GetLastAxis(handPose.inputSource));
            print(specialAction);
            switch (specialAction) {
                // Enable teleporting
                case 0: {
                    teleportDown = true;
                    break;
                }
                // Mulligan
                case 1: {
                    Mulligan();
                    break;
                }
                // Teleport to Ball
                case 2: {
                    TeleportToBall();
                    break;
                }
                // Display UI
                case 3: {
                    ToggleScoreUI(true);
                    break;
                }
                default:break;
            }
        }

        // Detect button up
        if (teleportAction.GetLastStateUp(handPose.inputSource)) {

            int specialAction = ConvertTouchPadButtons(touchpadButtons.GetLastAxis(handPose.inputSource));
            switch (specialAction) {
                // Enable teleporting
                case 0: {
                    teleportDown = false;
                    TeleportUp();
                    break;
                }

                default: {
                    ToggleScoreUI(false);
                    break;
                }
            }
        }

        if (teleportDown) {
            TeleportDown();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Interactable") && !other.CompareTag("Ball")) {
            return;
        }

        interactables.Add(other.gameObject.GetComponent<Interactable>());
        // Highlight closest object
        Interactable closest = GetNearestInteractable();
        foreach(Interactable item in interactables) {
            if(item == closest) {
                item.ToggleHighlight(true);
            } else {
                item.ToggleHighlight(false);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Interactable") && !other.CompareTag("Ball")) {
            return;
        }

        interactables.Remove(other.gameObject.GetComponent<Interactable>());
        other.gameObject.GetComponent<Interactable>().ToggleHighlight(false);
    }

    // Find the nearest interactable object and attempt to pick it up
    public void Pickup() {
        heldObject = GetNearestInteractable();

        if (!heldObject) {
            return;
        }

        // Force other hand to drop if already held
        if (heldObject.activeHand) {
            heldObject.activeHand.Drop();
        } else {
            // If the object is a ball, update the ball's last position
            Ball ball = heldObject.GetComponent<Ball>();
            if (ball) {
                ball.UpdateLastPosition();
            }
        }

        // Indicate that the player is holding an object, so that they cannot teleport
        handsAreFree = false;

        // Attach to joint
        Rigidbody targetBody = heldObject.GetComponent<Rigidbody>();
        targetBody.isKinematic = true;

        // Store active hand
        heldObject.activeHand = this;

    }
    
    // Drop a held object
    public void Drop() {
        if (!heldObject) {
            return;
        }

        // Count throws if object is ball
        if (heldObject.GetComponent<Ball>()) {
            score.Roll();

        }

        // Apply physics and break joint
        Rigidbody targetBody = heldObject.GetComponent<Rigidbody>();
        ReleaseFromJoint(targetBody);
        targetBody.velocity = handPose.GetVelocity();
        targetBody.angularVelocity = handPose.GetAngularVelocity() * angularVelocityModifier;

        // Disconnect the object
        //heldObject.GetComponent<Ball>().Release();
        Ball ball = heldObject.GetComponent<Ball>();
        if (ball) {
            ball.Release();
        }
        heldObject = null;

        // Allow the player to teleport
        handsAreFree = true;

    }

    // Returns the interactable object closest to the hand
    private Interactable GetNearestInteractable() {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(Interactable nearby in interactables) {
            distance = (nearby.transform.position - transform.position).sqrMagnitude;

            if(distance < minDistance) {
                minDistance = distance;
                nearest = nearby;
            }
        }

        return nearest;
    }

    // Try to find a valid teleport location, shown by a marker
    private void TeleportDown() {
        // Cancel if holding ball
        if (heldObject || isTeleporting || !handsAreFree) {
            return;
        }

        // Enable teleport marker if disabled
        if (!teleportMarkerInstance.activeSelf) {
            teleportMarkerInstance.SetActive(true);
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit)) {
            if (hit.collider.CompareTag("Walkable")) {
                teleportMarkerInstance.transform.position = hit.point;
                
            }
        }
    }

    // Attempt to teleport if there is a valid location found, otherwise abort
    private void TeleportUp() {
        if (teleportMarkerInstance.activeSelf && !isTeleporting) {
            
            Transform cameraRig = SteamVR_Render.Top().origin;
            Vector3 headPos = SteamVR_Render.Top().head.position;
            // Determine translation
            Vector3 groundPosition = new Vector3(headPos.x, cameraRig.position.y, headPos.z);
            Vector3 translation = teleportMarkerInstance.transform.position - groundPosition;

            // Move the rig
            StartCoroutine(MoveRig(cameraRig, translation));

            teleportMarkerInstance.SetActive(false);
        }

    }

    // Moves the player's rig with a slight fade and delay
    private IEnumerator MoveRig(Transform cameraRig, Vector3 translation) {
        isTeleporting = true;

        // Apply fade
        SteamVR_Fade.Start(Color.black, teleportDelay, true);

        yield return new WaitForSeconds(teleportDelay);

        // Move player
        cameraRig.position += translation;

        // End fade
        SteamVR_Fade.Start(Color.clear, teleportDelay, true);

        isTeleporting = false;

    }

    public SteamVR_Behaviour_Pose GetHandPose() {
        return handPose;
    }

    // Attaches an interactable object to the hand
    public void AttachToJoint() {
        // Force the object to be mapped to its (offset) and attach it to the fixed joint
        heldObject.transform.position = transform.position;
        Rigidbody targetBody = heldObject.GetComponent<Rigidbody>();
        grabJoint.connectedBody = targetBody;
        targetBody.isKinematic = false;

        // Haptic feedback
        SpecialInput.Pulse(0.2f, 150.0f, 15.0f, handPose.inputSource);
    }

    // Detaches an interactable object from the hand's fixed joint, freeing it
    public void ReleaseFromJoint(Rigidbody targetBody) {
        targetBody.isKinematic = false;
        grabJoint.connectedBody = null;
    }

    private int ConvertTouchPadButtons(Vector2 vectorInput) {
        if(vectorInput.y > 0.5) {
            return 0;
        }
        else if(vectorInput.y < -0.5f) {
            return 2;
        }

        else if(vectorInput.x < -0.3f) {
            return 1;
            //return handPose.inputSource == SteamVR_Input_Sources.LeftHand ? 3 : 1;
        }
        else if(vectorInput.x > 0.3f) {
            return 3;
            //return handPose.inputSource == SteamVR_Input_Sources.LeftHand ? 1 : 3;
        }

        return 0;
    }

    // Update and toggle the display for the UI on this hand
    private void ToggleScoreUI(bool on) {
        if (scoreUI) {  // Protect against null reference
            scoreUI.GetComponent<miniUI>().UpdateScore();
            if (scoreUI.activeSelf == on) {
                return; // Return if we are not changing state
            }       
            scoreUI.SetActive(on);
        }
    }

    // Allows the player to undo their most recent throw
    private void Mulligan() {
         if(mulliganCount < 1){return;}
        // Return ball
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball) {
            ball.GetComponent<Ball>().ReturnToLastPosition();
        }

        // Undo throw on score
        --score.currentLevelScore;

         --mulliganCount;
    }

    // Teleports the player directly to their ball - CURRENTLY UNSAFE
    private void TeleportToBall() {
        if (!isTeleporting) {
            GameObject ball = GameObject.FindGameObjectWithTag("Ball");
            if (!ball) {
                return;
            }
            Transform cameraRig = SteamVR_Render.Top().origin;
            Vector3 headPos = SteamVR_Render.Top().head.position;
            // Determine translation
            Vector3 groundPosition = new Vector3(headPos.x, cameraRig.position.y, headPos.z);
            Vector3 translation = ball.transform.position - groundPosition;

            // Move the rig
            StartCoroutine(MoveRig(cameraRig, translation));
        }
    }
}
