using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : Interactable
{

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    //private void Update() {
    //    if (activeHand) {
    //        Vector3 direction = (activeHand.transform.position - transform.position).normalized;
    //        rb.MovePosition(transform.position + direction * Time.deltaTime);
    //    }
    //}

}
