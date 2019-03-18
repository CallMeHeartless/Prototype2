using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed;
    public bool RotateX;
    public bool RotateY;
    public bool RotateZ;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateY)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
        }
        if (RotateX)
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.fixedDeltaTime);
        }
        if (RotateZ)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
