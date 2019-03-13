using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatchZoneController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball")) {
            other.GetComponent<Ball>().ReturnToLastPosition();
        }
    }

}
