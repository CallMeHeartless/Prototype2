using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultBallEffects : MonoBehaviour
{
    public int currentBall = 0;
    public GameObject[] balls;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //1 speed
        //2 weight
       

    }
    public void DifferentBall(GameObject newBall)
    {

        //Debug.Log(currentBall);
        if (currentBall != 2)
        {
            currentBall++;
        }
        else
        {
            currentBall = 0;
        }
        
        newBall = Instantiate(balls[currentBall], transform.position, transform.rotation);
        //newBall.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity;
        newBall.GetComponent<MultBallEffects>().currentBall = currentBall;
        newBall.GetComponent<Ball>().lastPosition = gameObject.GetComponent<Ball>().lastPosition;
        
    }
}
