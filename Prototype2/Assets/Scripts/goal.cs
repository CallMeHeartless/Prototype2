using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goal : MonoBehaviour
{
    public string nextLevelName;
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
        if (collision.gameObject.CompareTag("Interactable"))
        {
            StartCoroutine(waitAbit());
        }
          
    }
    IEnumerator waitAbit()
    {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(nextLevelName);
    }
}
