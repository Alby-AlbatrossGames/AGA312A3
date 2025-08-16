using UnityEngine;
using UnityEngine.SceneManagement;

public class ACButtonUtil : ACBehaviour
{

    // Attach to a UI Button for Actions and Util

    #region Public Variables
    [SerializeField] private float animationDuration = 0.3f;
    [SerializeField] private bool useUnscaledTime = false;
    #endregion Public Variables
    
    #region Scene Management
    public void ACBUTTONQuitApp() => Application.Quit();
    public void ACBUTTONLoadScene(string name) => SceneManager.LoadScene(name);
    public void ACBUTTONReloadScene() => ACBUTTONLoadScene(SceneManager.GetActiveScene().name);
    #endregion Scene Management

    #region ACEvents
    public void ACBUTTONTogglePause() => ACEvents.ReportOnPauseButtonPress();
    #endregion ACEvents

    #region Animations
    public void ACBUTTONDoScale(float scale) => ACDoScale(GetComponent<RectTransform>(), scale, animationDuration, useUnscaledTime);
    #endregion Animations
}
