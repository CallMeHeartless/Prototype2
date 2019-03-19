using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultBallEffects : MonoBehaviour
{
    public int currentBall = 0;
    public PhysicMaterial bounce;
    public PhysicMaterial noBounce;
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
           
            case 0:
                GameObject[] AllFloor = GameObject.FindGameObjectsWithTag("Walkable");
                for (int i = 0; i < AllFloor.Length; i++)
                {
                    AllFloor[i].GetComponent<MeshCollider>().material = noBounce;
                }
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
            case 3:
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.GetChild(0).GetComponent<SphereCollider>().radius = 1.25f;
                player.transform.GetChild(1).GetComponent<SphereCollider>().radius = 1.25f;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                currentBall++;
                break;
            case 4:
                GameObject[] AllFloorB = GameObject.FindGameObjectsWithTag("Walkable");
                for (int i = 0; i < AllFloorB.Length; i++)
                {
                    AllFloorB[i].GetComponent<MeshCollider>().material = bounce;
                }
                currentBall = 0;
                break;
            default:
                break;
        }
        
        Debug.Log(currentBall);
    }
}
