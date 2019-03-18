using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    bool fristhit = true;
    
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
        if (fristhit)
        {
            if (collision.gameObject.CompareTag("Interactable") || collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Pin"))
            {
                fristhit = false;
                score.Pins++;
                StartCoroutine(waitAbit());

            }
        }
        
        
          
    }
    IEnumerator waitAbit()
    {
        yield return new WaitForSeconds(4);
        
        print(score.Pins);
        Destroy(gameObject);
        //
        
    }
}
