using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public static int[] scoreBoard = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };//9
    public static int currentLevelScore = 0;
    public static int levelNumber = 0;
    public static int Pins = 1;
    public static string levelName;
    playerScore tem = new playerScore();
    // Start is called before the first frame update
   
    public static void Nextlevel()
    {
        
            if(levelName != "") {
                SceneManager.LoadScene(levelName);
            } else {
                print("Level completed");
            }

    
    }
    public static void Roll()
    {
        currentLevelScore++;
    }

    public void loadScore() {
        if (PlayerPrefs.HasKey("highestScore"))
        {
            tem.Lowscore = PlayerPrefs.GetInt("highestScore");
        }
    }
    public void SaveScore()
    {
        if (PlayerPrefs.HasKey("highestScore"))
        {
            PlayerPrefs.SetInt("highestScore", tem.Lowscore);
        }
    }
    public void newscore(int score)
    {
        
        if (score < tem.Lowscore)
        {
            tem.Lowscore = score;
            SaveScore();
        }
    }
    }
