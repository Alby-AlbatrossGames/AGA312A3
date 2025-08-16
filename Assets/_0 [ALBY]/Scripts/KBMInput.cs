using UnityEngine;

public class KBMInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ACEvents.ReportOnPauseButtonPress();
    }
}
