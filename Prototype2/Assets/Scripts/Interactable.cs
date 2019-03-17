using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public GameObject highlight;

    [HideInInspector]
    public Hand activeHand = null;

    public virtual void Use() {

    }

    public void ToggleHighlight(bool on) {
        if (highlight) {
            highlight.SetActive(on);
        }

    }

}
