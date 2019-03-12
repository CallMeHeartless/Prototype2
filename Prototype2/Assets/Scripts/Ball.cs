using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : Interactable
{

    private Rigidbody rb;
    private bool hasReachedHand = false;
    [SerializeField]
    private float translationSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    //private void FixedUpdate() {
    //    if (activeHand && !hasReachedHand) {
    //        Vector3 direction = activeHand.transform.position - transform.position;
    //        if(direction.sqrMagnitude > 0.1f) {
    //            rb.MovePosition(transform.position + direction * translationSpeed * Time.fixedDeltaTime);
    //        } else {
    //            rb.MovePosition(activeHand.transform.position);
    //            hasReachedHand = true;
    //            activeHand.AttachToJoint();
    //        }

            
    //    }
    //}

}
