using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SpecialInput : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Boolean resetAction = null;
    private static SteamVR_Action_Vibration hapticAction;

    // Update is called once per frame
    void Update()
    {
        if (resetAction.GetStateDown(SteamVR_Input_Sources.Any)) {
            Resetable.ResetAllPositions();
        }
    }

    public static void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source) {
        hapticAction.Execute(0.0f, duration, frequency, amplitude, source);

    }
}
