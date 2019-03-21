using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class SpecialInput : MonoBehaviour
{
    private static SpecialInput instance = null;

    [SerializeField]
    private SteamVR_Action_Boolean resetAction = null;
    public SteamVR_Action_Vibration hapticAction;

    [SerializeField]
    private GameObject barrier;

    private void Awake() {
        instance = this;
        score.playerScore = 0;
        // Reset score when the level is loaded
        score.playerThrowCount = 0;
        score.playerScore = 0;
        score.levelName = SceneManager.GetActiveScene().name;
        print(score.levelName);
    }

    // Update is called once per frame
    void Update()
    {
        //if (resetAction.GetStateDown(SteamVR_Input_Sources.Any)) {
        //    Resetable.ResetAllPositions();
        //}
    }

    public static void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source) {
        instance.hapticAction.Execute(0.0f, duration, frequency, amplitude, source);

    }

    public void SetBarrierDimensions() {
        HmdQuad_t pRect = new HmdQuad_t();
        if (OpenVR.Chaperone.GetPlayAreaRect(ref pRect)) {
            // Calculate scale
            Vector3 rectSize = new Vector3(1.0f, 1.0f, 1.0f);
            rectSize.x = Mathf.Abs(pRect.vCorners0.v0 - pRect.vCorners1.v0) / 2.0f;
            rectSize.z = Mathf.Abs(pRect.vCorners1.v2 - pRect.vCorners1.v2) / 2.0f;
            // Apply to shape
            if (barrier) {
                barrier.transform.localScale = rectSize;
            }
        }
    }
}
