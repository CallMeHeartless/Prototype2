using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    [Header("Control")]
    public bool isMoving = false;
    public bool isRotating = false;
    public float speed;
    public float rotationSpeed;
    private bool movingForwards = true;

    [Header("Targets")]
    public GameObject[] moveTo;
    public Transform goal;
    public int CurrentGoal;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGoal = 0;
        goal = moveTo[0].transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(transform.position, moveTo[CurrentGoal].transform.position) <= 0.2f)//at loctation
        //{
            
        //    if (CurrentGoal == moveTo.Length-1)
        //    {
        //        CurrentGoal = 0;
        //    }
        //    else
        //    {
        //        CurrentGoal++;
        //    }
        //    goal = moveTo[CurrentGoal].transform;
        //}
        //transform.position = Vector3.MoveTowards(transform.position, moveTo[CurrentGoal].transform.position, speed * Time.deltaTime);
    }

    private void FixedUpdate() {
        if (isMoving) {
            MoveObject();
        }
        if (isRotating) {
            RotateObject();
        }
    }

    private void MoveObject() {
        if (Vector3.Distance(transform.position, moveTo[CurrentGoal].transform.position) <= 0.2f)//at loctation
        {
            if (movingForwards) {
                ++CurrentGoal;
                CheckForEndOfArray();
            } else {
                --CurrentGoal;
                CheckForEndOfArray();
            }


            
            goal = moveTo[CurrentGoal].transform;
        }
        transform.position = Vector3.MoveTowards(transform.position, moveTo[CurrentGoal].transform.position, speed * Time.deltaTime);
    }

    private void RotateObject() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
    }

    private void CheckForEndOfArray() {
        if (CurrentGoal > moveTo.Length - 1) {
            CurrentGoal = moveTo.Length - 2;
            movingForwards = false;
        } else if (CurrentGoal < 0) {
            CurrentGoal = 1;
            movingForwards = true;
        }
    }
}
