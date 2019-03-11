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

    // Teleport marker
    [SerializeField]
    private GameObject teleportPrefab;
    private GameObject teleportMarkerInstance = null;

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

    public void Pickup() {
        heldObject = GetNearestInteractable();

        if (!heldObject) {
            return;
        }

        if (heldObject.activeHand) {
            heldObject.activeHand.Drop();
        }

        Rigidbody targetBody = heldObject.GetComponent<Rigidbody>();
        grabJoint.connectedBody = targetBody;

        heldObject.activeHand = this;

    }

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

    private void TeleportDown() {
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

    private void TeleportUp() {
        if (teleportMarkerInstance.activeSelf) {
            transform.root.position = teleportMarkerInstance.transform.position;
            teleportMarkerInstance.SetActive(false);
        }

    }

}
