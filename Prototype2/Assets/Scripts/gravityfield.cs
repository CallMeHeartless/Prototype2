﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityfield : MonoBehaviour
{
    public float gravityeffect;
    public Vector3 newgrvity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){

        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Ball")|| other.gameObject.CompareTag("Pin"))
    //    {
    //        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * gravityeffect, ForceMode.Acceleration);
    //        Debug.Log("still");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Pin"))
        {
            Physics.gravity = newgrvity;
            //effect slef gravity
        }
        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Pin"))
        {
            Physics.gravity = new Vector3(0,9.81f,0);
            //effect slef gravity 
        }
        //    other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
