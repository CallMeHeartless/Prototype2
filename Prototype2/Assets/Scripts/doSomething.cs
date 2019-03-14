using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doSomething : MonoBehaviour
{
    bool fristhit = true;
    public GameObject ChangeObject;
    public bool Switch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactable") || collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Pin"))
        
        {
            Debug.Log("dfhsh");
            if (Switch)
            {
                if (fristhit)
                {
                    ChangeObject.GetComponent<MovingObjectOnCall>().CurrentGoal = 1;
                    fristhit = false;
                }
                else
                {
                    ChangeObject.GetComponent<MovingObjectOnCall>().CurrentGoal = 0;
                    fristhit = true;
                }
            }
            else
            {
                if (fristhit)
                {
                    ChangeObject.GetComponent<MovingObjectOnCall>().CurrentGoal = 1;
                    fristhit = false;
                }
            }
        }
        
    }
}
