using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        score.scoreBoard[score.levelNumber - 1] = score.playerThrowCount;
        score.playerThrowCount = 0;
        score.levelNumber++;

    }

}
