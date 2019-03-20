using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class miniUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    
    public void UpdateScore() {
        int totalScore = score.playerScore - score.playerThrowCount;
        scoreText.text = "Current Score: " + score.playerScore + " | Throws: " + score.playerThrowCount + "\nTotal Score: " + totalScore;
        // Update high score
        if (totalScore > PlayerPrefs.GetInt("HighScore" + score.levelName, 0)) {
            PlayerPrefs.SetInt("HighScore" + score.levelName, totalScore);
        }
        scoreText.text += "\nHigh Score: " + PlayerPrefs.GetInt("HighScore" + score.levelName, 0);
    }
}
