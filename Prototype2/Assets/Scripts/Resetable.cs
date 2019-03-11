using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetable : MonoBehaviour
{

    private Vector3 startPosition;
    private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Returns the object to its original position and rotation and zeroes its velocity 
    public void ResetPosition() {
        transform.position = startPosition;
        transform.rotation = startRotation;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb) {
            rb.velocity = Vector3.zero;
        }
    }

    public static void ResetAllPositions() {
        Resetable[] objects = GameObject.FindObjectsOfType<Resetable>();
        foreach(Resetable item in objects) {
            item.ResetPosition();
        }
    }
}
