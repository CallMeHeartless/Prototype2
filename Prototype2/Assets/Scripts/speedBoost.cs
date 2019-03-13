using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBoost : MonoBehaviour
{
    // Start is called before the first frame update
    public float boost;
    public Vector3 boostDirection;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Pin"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(boostDirection * boost, ForceMode.VelocityChange);
        }
       // other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 18, 0), ForceMode.Acceleration);
        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
}
