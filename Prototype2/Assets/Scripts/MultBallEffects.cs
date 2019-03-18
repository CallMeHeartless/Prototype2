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
        //1 speed
        //2 weight
        //3 is boomrange

    }
    public void DifferentBall(){

        switch (currentBall) { 
            case 3:
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.GetChild(0).GetComponent<SphereCollider>().radius = 1.25f;
                player.transform.GetChild(1).GetComponent<SphereCollider>().radius = 1.25f;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                currentBall = 0;
                break;
            case 0:
                currentBall++;
                break;
            case 1:
                GetComponent<Rigidbody>().mass = 2;
                currentBall++;
                break;
            case 2:
                GetComponent<Rigidbody>().mass = 8;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                GameObject playerDO = GameObject.FindGameObjectWithTag("Player");
                playerDO.transform.GetChild(0).GetComponent<SphereCollider>().radius = 6;
                playerDO.transform.GetChild(1).GetComponent<SphereCollider>().radius = 6;
                currentBall++;
                break;
            default:
                break;
        }
        
        Debug.Log(currentBall);
    }
}
