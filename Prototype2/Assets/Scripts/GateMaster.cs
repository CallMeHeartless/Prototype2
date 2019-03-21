using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject portal;
    [SerializeField][Tooltip("The number of gates that must be triggered in order for the portal to appear")]
    private float numberOfGatesRequired;
    List<Transform> childGates = new List<Transform>();

    void Start()
    {
        for(int i = 0; i < transform.childCount; ++i) {
            childGates.Add(transform.GetChild(i));
            //print(transform.GetChild(i).name);
        }
        if (!childGates[0]) {
            Debug.LogError("ERROR: Child gates are missing from gate master. Null reference exception will follow");
        }
        if (!portal) {
            //portal = GameObject.Find("Portal");
            print("That was the error");
        }
    }

    public void UpdateGateState() {
        if (GetNumberOfClosedGates() >= numberOfGatesRequired) {
            //portal.SetActive(true);
            //portal.GetComponent<Portal>().TurnOn();
            if (portal.GetComponent<Portal>()) {
                portal.GetComponent<Portal>().TurnOn();
            } else {
                Debug.LogError("ERROR: Gate Master cannot find Portal script for portal reference.");
            }
        }
    }


    // Checks if all gates have been closed
    private bool CheckGatesAreClosed() {
        if (childGates[0]) {
            foreach (Transform gate in childGates) {
                if (!gate.gameObject.GetComponent<GateController>().hasBeenTriggered) {
                    return false;
                }
            }
        }
        return true;
    }

    private int GetNumberOfClosedGates() {
        int count = 0;
        if (childGates[0]) {
            foreach(Transform gate in childGates) {
                if (gate.gameObject.GetComponent<GateController>().hasBeenTriggered) {
                    ++count;
                }
            }
        }
        return count;
    }
}
