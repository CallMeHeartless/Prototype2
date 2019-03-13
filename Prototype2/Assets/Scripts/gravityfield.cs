using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityfield : MonoBehaviour
{
    public float gravityeffect;
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
    private void OnTriggerStay(Collider other)
    {

        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0)* gravityeffect, ForceMode.Acceleration);
        Debug.Log("still");
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 18, 0) , ForceMode.Acceleration);
        //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    //}
}
