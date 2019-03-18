using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float MaxTimer;
    public float Timer;
    public GameObject WhatToSpawn;
    public Vector3 MoveObject;
    // Start is called before the first frame update
    void Start()
    {
        Timer = MaxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= 0)
        {
            Timer = MaxTimer;
            GameObject Item = Instantiate(WhatToSpawn, transform.position, transform.rotation);
             
            Item.GetComponentInChildren<Rigidbody>().AddForce(MoveObject, ForceMode.Acceleration);

        }
        Timer -= Time.deltaTime;
    }
}
