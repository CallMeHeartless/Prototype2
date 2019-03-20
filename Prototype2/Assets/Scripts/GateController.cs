using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField]
    private Color closedColour;
    public bool hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball") && !hasBeenTriggered) {
            hasBeenTriggered = true;
            // Tell parent to update status
            transform.root.GetComponent<GateMaster>().UpdateGateState();
            // Update visuals
            ParticleSystem gateParticles = GetComponent<ParticleSystem>();
            if (gateParticles) {
                ParticleSystem.MainModule main = gateParticles.main;
                main.startColor = closedColour;
            }
        }
    }

}
