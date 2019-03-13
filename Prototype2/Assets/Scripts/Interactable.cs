using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [HideInInspector]
    public Hand activeHand = null;

    public virtual void Use() {

    }

}
