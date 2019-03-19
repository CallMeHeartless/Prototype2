using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public GameObject highlight;

    [HideInInspector]
    public Hand activeHand = null;
    [HideInInspector]
    public bool hasReachedHand = false;
    [SerializeField]
    protected float grabThreshold = 0.01f;
    [SerializeField]
    protected float translationSpeed = 3.0f;

    public virtual void Use() {

    }

    protected virtual void FixedUpdate() {
        if(activeHand && !hasReachedHand) {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 direction = activeHand.transform.position - transform.position;
            if (direction.sqrMagnitude > grabThreshold) {
                if (rb) {
                    // Translate via rigidbody
                    rb.MovePosition(transform.position + direction.normalized * translationSpeed * Time.fixedDeltaTime);
                } else {
                    // Translate without rigidbody
                    transform.Translate(direction.normalized * translationSpeed * Time.fixedDeltaTime);
                }
               
            } else {
                //rb.MovePosition(activeHand.transform.position);
                hasReachedHand = true;
                activeHand.AttachToJoint();
            }

        }
    }

    public virtual void Release() {
        activeHand = null;
        hasReachedHand = false;
    }

    public void ToggleHighlight(bool on) {
        if (highlight) {
            highlight.SetActive(on);
        }

    }

}
