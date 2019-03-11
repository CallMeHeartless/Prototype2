using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetable : MonoBehaviour
{

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition() {
        transform.position = startPosition;
    }

    public static void ResetAllPositions() {
        Resetable[] objects = GameObject.FindObjectsOfType<Resetable>();
        foreach(Resetable item in objects) {
            item.ResetPosition();
        }
    }
}
