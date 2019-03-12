using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{
    public float boost;
    public Vector3 boostDirection;
    // Start is called before the first frame update


   private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(boostDirection * boost, ForceMode.Force);

        // other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 18, 0), ForceMode.Acceleration);
        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
}
