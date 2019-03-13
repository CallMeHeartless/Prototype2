using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newGravityPoint : MonoBehaviour
{
    public float gravityeffect;
    public Vector3 newGravity;
    public bool OnlyY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            newGravity = gameObject.transform.parent.GetChild(1).transform.position - other.transform.position;
            newGravity = newGravity.normalized;
            if (OnlyY == true)
            {
                newGravity.x = 0;
                newGravity.z = 0;
            }
            newGravity.y = newGravity.y * 9.81f;
            Physics.gravity = newGravity;
        }
        // other.GetComponent<Rigidbody>().velocity = new Vector3(other.GetComponent<Rigidbody>().velocity.x, other.GetComponent<Rigidbody>().velocity.y/2 , other.GetComponent<Rigidbody>().velocity.z);
        // other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0)* gravityeffect, ForceMode.Acceleration);
        //Debug.Log("still");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            newGravity = gameObject.transform.parent.GetChild(1).transform.position + other.transform.position;
            newGravity = newGravity.normalized;
            if (OnlyY == true)
            {
                newGravity.x = 0;
                newGravity.z = 0;
            }
            newGravity.y = newGravity.y * 9.81f;
            Physics.gravity = newGravity;
            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 9.81f, 0), ForceMode.Acceleration);

            Debug.Log("zero");
            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 18, 0) , ForceMode.Acceleration);
            //other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
            Debug.Log("reset");
        }
        //other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
