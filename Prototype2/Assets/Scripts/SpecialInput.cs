using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpecialInput : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Boolean resetAction = null;

    // Update is called once per frame
    void Update()
    {
        if (resetAction.GetStateDown(SteamVR_Input_Sources.Any)) {
            Resetable.ResetAllPositions();
        }
    }
}
