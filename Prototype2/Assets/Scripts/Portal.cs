using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string nextLevel;
    private bool hasBeenActivated = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball") && !hasBeenActivated) {
            // Load the next level
            hasBeenActivated = true;
            SceneManager.LoadScene(nextLevel);
        }
    }

}
