﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class miniUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  //  void Update()
   // {
        //transform.GetChild(0).GetComponent<Text>().text = score.levelNumber.ToString();
        //transform.GetChild(1).GetComponent<Text>().text = score.currentLevelScore.ToString();
    //}

    public void UpdateScore() {
        scoreText.text = "Current Score: " + score.currentLevelScore + " | Best Score: ";
    }
}
