using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class allscores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int total = 0;
        for (int i = 0; i < 9; i++)
        {
            transform.GetChild(i).GetComponent<Text>().text = score.scoreBoard[i].ToString();
            total += score.scoreBoard[i];
        }
        transform.GetChild(9).GetComponent<Text>().text = total.ToString();
       
    }
}
