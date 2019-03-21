using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpaceCubeController : MonoBehaviour
{
    // Member variables
    [SerializeField]
    private int pointsValue = 5;
    [SerializeField]
    private float speedMultiplier = 1.25f;
    private Animator anim;
    private bool hasBeenTriggered = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Ball") && !hasBeenTriggered) {
            hasBeenTriggered = true; // Ensure script triggers only once
            // Increase score
            score.playerScore += pointsValue;
            // Trigger animation
            anim.SetTrigger("Pickup");

            // Apply speed boost
            other.GetComponent<Rigidbody>().velocity *= speedMultiplier;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void RemoveCube() {
        Destroy(gameObject);
    }
}
