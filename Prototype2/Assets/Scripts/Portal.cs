using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string nextLevel;
    private bool hasBeenActivated = false;
    private static float transitionDelay = 3.0f;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball") && !hasBeenActivated) {
            // Load the next level
            hasBeenActivated = true;
            StartCoroutine(LevelTransition());
        }
    }

    private IEnumerator LevelTransition() {
        yield return new WaitForSeconds(transitionDelay);
        SceneManager.LoadScene(nextLevel);
    }

    public void TurnOn() {
        // Activate collider
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.enabled = true;
        // Turn on VFX
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);
        print("Portal turned on");
    }

}
