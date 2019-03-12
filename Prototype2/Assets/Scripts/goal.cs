using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goal : MonoBehaviour
{
    public string nextLevelName;
    private bool FirstHIt = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void OnCollisionEnter(Collision collision)
    {
        if (FirstHIt == false)
        {


            if (collision.gameObject.CompareTag("Interactable"))
            {
                score.Pins--;
                if (score.Pins != 0)
                {
                    StartCoroutine(waitAbit());

                }
                else
                {
                    score.Nextlevel();
                    StartCoroutine(loadNext());
                }
                FirstHIt = true;

            }
        }
          
    }
    IEnumerator loadNext()
    {
        //ball can't be picked up
        //ui pop up

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(nextLevelName);
        
    }
    IEnumerator waitAbit()
    {
        yield return new WaitForSeconds(4);

        Destroy(gameObject);
    }
}
