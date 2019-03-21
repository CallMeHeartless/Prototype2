using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    // 'Button' references
    public GameObject[] toggleButtons;
    public bool isToggleButton;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        // Check that it's the player
        if (other.GetComponent<Hand>()) {
            if (isToggleButton) {
                // Switch the status of the target buttons, turn self off
                if (!toggleButtons[0]) {
                    return;
                }
                foreach(GameObject button in toggleButtons) {
                    button.SetActive(!button.activeSelf);
                }
                gameObject.SetActive(false);
            } else {
                // Exit application
                Application.Quit();
            }
        }
    }
}
