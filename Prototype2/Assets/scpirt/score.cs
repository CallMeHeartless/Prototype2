using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public static int[] scoreBoard = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };//9
    public static int currentLevelScore = 0;
    public static int levelNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public static void Nextlevel()
    {
        scoreBoard[levelNumber-1] = currentLevelScore;
        currentLevelScore = 0;
        levelNumber++;
    }
    public static void Roll()
    {
        currentLevelScore++;
    }
}
