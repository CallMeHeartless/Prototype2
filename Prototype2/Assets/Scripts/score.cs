using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public static int[] scoreBoard = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };//9
    public static int currentLevelScore = 0;
    public static int levelNumber = 1;
    public static int Pins = 1;
    public static string levelName;
    // Start is called before the first frame update
   
    public static void Nextlevel()
    {
        if (Pins == 0)
        {
            scoreBoard[levelNumber - 1] = currentLevelScore;
            currentLevelScore = 0;
            levelNumber++;
            if(levelName != "") {
                SceneManager.LoadScene(levelName);
            } else {
                print("Level completed");
            }

        }
    
    }
    public static void Roll()
    {
        currentLevelScore++;
    }

}
