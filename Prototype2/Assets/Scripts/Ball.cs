using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : Interactable
{
    // Components
    private Rigidbody rb;

    private Vector3 lastPosition;
    public bool hasReachedHand = false;
    [SerializeField]
    private float translationSpeed = 3.0f;
    [SerializeField]
    private float grabThreshold = 0.01f;
    public float increaseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
        
    }

    private void FixedUpdate() {
        if (activeHand && !hasReachedHand) {

            Vector3 direction = activeHand.transform.position - transform.position;
            if (direction.sqrMagnitude > grabThreshold) {
                rb.MovePosition(transform.position + direction.normalized * translationSpeed * Time.fixedDeltaTime);
            } else {
                //rb.MovePosition(activeHand.transform.position);
                hasReachedHand = true;
                activeHand.AttachToJoint();
            }


        }
    }

    public void Release() {
        if (GetComponent<MultBallEffects>().currentBall == 1) {
            rb.velocity = new Vector3( rb.velocity.x * increaseSpeed, rb.velocity.y, rb.velocity.z * increaseSpeed);
        }
        activeHand = null;
        hasReachedHand = false;
    }

    public void UpdateLastPosition() {
        lastPosition = transform.position;
    }

    public void ReturnToLastPosition() {
        transform.position = lastPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
