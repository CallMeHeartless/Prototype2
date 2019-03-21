using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : Interactable
{
    // Components
    private Rigidbody rb;

    public Vector3 lastPosition;


    public bool held = false;
    public float increaseSpeed;
    public float increaseHeight;
    public bool canMove = true;
    public float delay = 4;
    AudioSource[] audio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
        
    }

    protected override void FixedUpdate() {
        if (activeHand && !hasReachedHand) {

           // if (GetComponent<MultBallEffects>().currentBall != 3)
            {
                lastPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);


                Vector3 direction = activeHand.transform.position - transform.position;
                if (direction.sqrMagnitude > grabThreshold)
                {
                    rb.MovePosition(transform.position + direction.normalized * translationSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    //rb.MovePosition(activeHand.transform.position);
                    hasReachedHand = true;
                    activeHand.AttachToJoint();
                }
            //}
            //else {
            //    if (!canMove)//doesn't hit something
            //      {
            //        Vector3 direction = new Vector3(activeHand.transform.position.x, 0, activeHand.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z);
                        
            //            if (direction.sqrMagnitude > grabThreshold) {

            //                rb.MovePosition(transform.position + direction.normalized * translationSpeed * Time.fixedDeltaTime);

    
            //            } else {
            //                //rb.MovePosition(activeHand.transform.position);
            //                hasReachedHand = true;
            //                activeHand.AttachToJoint();
            //            }
            }

        }

    }

    public override void Release() {
        if (GetComponent<MultBallEffects>().currentBall == 1) {
            rb.velocity = new Vector3( rb.velocity.x * increaseSpeed, rb.velocity.y, rb.velocity.z * increaseSpeed);
        }
        else
        {
            if (GetComponent<MultBallEffects>().currentBall == 2)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * increaseHeight, rb.velocity.z);
            }
        }
        base.Release();
    }

    public void UpdateLastPosition() {

        lastPosition = transform.position;
     
    }

    public void ReturnToLastPosition() {
        transform.position = lastPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        audio[1].Play();

    }
    IEnumerator CouldMove()
    {
        //lastPosition = transform.position;
        canMove = false;
        yield return new WaitForSeconds(delay);
        canMove = true;
    }
}
