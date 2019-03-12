using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int dum = 0;
        GameObject[] AllPin = GameObject.FindGameObjectsWithTag("Pin");
        score.Pins = AllPin.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
