using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultBallEffects : MonoBehaviour
{
    public int currentBall = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DifferentBall(){
        if (currentBall != 3)
        {
            currentBall++;
        }
        else
        {
            currentBall = 0;
        }
    }
}
