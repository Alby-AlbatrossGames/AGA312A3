using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject pauseMenu;
    public UnityEvent OnPause;
    public UnityEvent OnUnpause;

    private void Setup()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }
    private void TogglePause()
    {
        isPaused =! isPaused;
        switch (isPaused)
        {
            case false:
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                OnUnpause.Invoke();
                break;
            case true:
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                OnPause?.Invoke();
                break;
        }
    }

    private void OnEnable()
    {
        Setup();
        ACEvents.OnPauseButtonPress += TogglePause;
    }
    private void OnDisable()
    {
        ACEvents.OnPauseButtonPress -= TogglePause;
    }
}
