using System.Collections;
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
        // Reset score when the level is loaded
        score.playerThrowCount = 0;
        score.playerScore = 0;
    }

    public void UpdateScore() {
        int totalScore = score.playerScore - score.playerThrowCount;
        scoreText.text = "Current Score: " + score.playerScore + " | Throws: " + score.playerThrowCount + "\nTotal Score: " + totalScore;
        // Update high score
        if (totalScore > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", totalScore);
        }
        scoreText.text += "\nHigh Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
}
