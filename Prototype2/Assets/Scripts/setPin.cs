using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPin : MonoBehaviour
{
    public string nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
     
       // GameObject[] AllPin = GameObject.FindGameObjectsWithTag("Pin");
        //score.Pins = AllPin.Length;
        score.levelName = nextLevelName;
        //print(AllPin.Length);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
