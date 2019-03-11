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

    // Hand variables
    private SteamVR_Behaviour_Pose handPose = null;
    private FixedJoint grabJoint = null;

    // Held object
    private Interactable heldObject = null;
    private List<Interactable> interactables = new List<Interactable>();

    // Teleport
    [SerializeField]
    private GameObject teleportPrefab = null;
    private GameObject teleportMarkerInstance = null;
    private bool isTeleporting = false;
    [SerializeField]
    private float teleportDelay = 0.5f;

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
        teleportMarkerInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (grabAction.GetLastStateDown(handPose.inputSource)) {
            Pickup();
        }

        if (grabAction.GetLastStateUp(handPose.inputSource)) {
            Drop();
        }

        // Teleporting
        if (teleportAction.GetLastState(handPose.inputSource)) {
            TeleportDown();
        }

        if (teleportAction.GetLastStateUp(handPose.inputSource)) {
            TeleportUp();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Interactable")) {
            return;
        }

        interactables.Add(other.gameObject.GetComponent<Interactable>());
    }

    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Interactable")) {
            return;
        }

        interactables.Remove(other.gameObject.GetComponent<Interactable>());
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
        }

        // Update position
        heldObject.transform.position = transform.position;

        // Attach to joint
        Rigidbody targetBody = heldObject.GetComponent<Rigidbody>();
        grabJoint.connectedBody = targetBody;

        // Store active hand
        heldObject.activeHand = this;

    }
    
    // Drop a held object
    public void Drop() {
        if (!heldObject) {
            return;
        }

        // Apply physics
        Rigidbody targetBody = heldObject.GetComponent<Rigidbody>();
        targetBody.velocity = handPose.GetVelocity();
        targetBody.angularVelocity = handPose.GetAngularVelocity();

        // Disconnect the object
        grabJoint.connectedBody = null;
        heldObject.activeHand = null;
        heldObject = null;
    }

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
        if (heldObject) {
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
            //transform.root.position = teleportMarkerInstance.transform.position;
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

}
