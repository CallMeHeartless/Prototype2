using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    public float forceStrength;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)

    {

        //Debug.Log("hitting");
        if (other.gameObject.CompareTag("Interactable") || other.gameObject.CompareTag("Ball") || other.gameObject.CompareTag("Pin"))
        {
            Debug.Log("player");
            Vector3 direction = other.transform.position - transform.position;
            direction.y = 0; // Remove vertical component to knock back
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * forceStrength, ForceMode.Impulse);
        }
    }
}