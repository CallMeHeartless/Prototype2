using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

    public bool hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball")) {
            hasBeenTriggered = true;
        }
    }
}
