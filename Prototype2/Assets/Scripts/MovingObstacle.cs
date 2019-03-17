using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    public bool isMoving = false;
    public bool isRotating = false;
    private bool travellingForwards = true;

    [SerializeField]
    Transform[] travelPoints;
    private int travelIndex = 0;
    [SerializeField]
    private float translationSpeed = 1.0f;
    [SerializeField]
    private float rotationSpeed = 5.0f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Update direction
        if(transform.position == travelPoints[travelIndex].position) {
            if (travellingForwards) {
                ++travelIndex;
                if(travelIndex == travelPoints.Length) {
                    travellingForwards = false;
                    travelIndex -= 2;
                }
            } else {
                --travelIndex;
                if(travelIndex == -1) {
                    travellingForwards = true;
                    travelIndex += 2;
                }
            }
        }
        
    }

    private void FixedUpdate() {
        // Move the object
        if (isMoving) {
            if(travelPoints[0] == null) {
                return;
            }
            // Calculate the vector to the next target
            Vector3 direction = travelPoints[travelIndex].position - transform.position;
            if(direction.sqrMagnitude < 0.05f) {
                transform.position = travelPoints[travelIndex].transform.position;
            } else {
                //rb.MovePosition(transform.position +  translationSpeed * direction.normalized * Time.fixedDeltaTime);
                transform.Translate(direction.normalized * translationSpeed * Time.fixedDeltaTime);
            }
        }

        // Rotate the object
        if (isRotating) {
            transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }


    }
}
