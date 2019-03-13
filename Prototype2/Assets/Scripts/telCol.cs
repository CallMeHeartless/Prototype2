using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telCol : MonoBehaviour
{
    public GameObject otherEnd;
    public Vector3 ExtraDis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            other.transform.position = otherEnd.transform.position;
        }
    }
}
