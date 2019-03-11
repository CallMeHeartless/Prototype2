using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class miniUI : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //testing 
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    score.Nextlevel();
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    score.Roll();
        //}
        

        transform.GetChild(0).GetComponent<Text>().text = score.levelNumber.ToString();
        transform.GetChild(1).GetComponent<Text>().text = score.currentLevelScore.ToString();
    }
}
