using UnityEngine;

public class KBMInput : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ACEvents.ReportOnPauseButtonPress();
    }
}
