using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectOnCall : MonoBehaviour
{
    public GameObject[] moveTo;
    public Transform goal;
    public int CurrentGoal;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        goal = moveTo[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Vector3.Distance(transform.position, moveTo[CurrentGoal].transform.position) <= 0.2f))//at loctation
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTo[CurrentGoal].transform.position, speed * Time.deltaTime);


        }
    }
}
