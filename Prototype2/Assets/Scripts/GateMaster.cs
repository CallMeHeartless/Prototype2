using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject portal;
    Transform[] childGates;

    void Start()
    {
        childGates = GetComponentsInChildren<Transform>();
        if (!childGates[0]) {
            Debug.LogError("ERROR: Child gates are missing from gate master. Null reference exception will follow");
        }
        if (!portal) {
            portal = GameObject.Find("Portal");
        }
    }

    public void UpdateGateState() {
        if (CheckGatesAreClosed()) {
            portal.SetActive(true);
        }
    }


    // Checks if all gates have been closed
    private bool CheckGatesAreClosed() {
        if (childGates[0]) {
            foreach (Transform gate in childGates) {
                if (!gate.GetComponent<GateController>().hasBeenTriggered) {
                    return false;
                }
            }
        }
        return true;
    }
}
