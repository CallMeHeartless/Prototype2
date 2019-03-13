using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    public GameObject[] moveTo;
    public Transform goal;
    public int CurrentGoal;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        CurrentGoal = 0;
        goal = moveTo[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, moveTo[CurrentGoal].transform.position) <= 0.2f)//at loctation
        {
            
            if (CurrentGoal == moveTo.Length-1)
            {
                CurrentGoal = 0;
            }
            else
            {
                CurrentGoal++;
            }
            goal = moveTo[CurrentGoal].transform;
        }
        transform.position = Vector3.MoveTowards(transform.position, moveTo[CurrentGoal].transform.position, speed * Time.deltaTime);
    }
}
