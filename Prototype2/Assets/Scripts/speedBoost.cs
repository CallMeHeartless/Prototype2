using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBoost : MonoBehaviour
{
    
    public float boost;
    public Vector3 boostDirection;
    public bool useForward = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Pin"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (!rb) {
                return;
            }
            if (useForward) {
                rb.velocity += transform.forward * boost;
            } else {
                rb.velocity += boostDirection * boost;
            }
            //other.gameObject.GetComponent<Rigidbody>().AddForce(boostDirection * boost, ForceMode.VelocityChange);
        }
    }
}
