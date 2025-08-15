using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;

public class ACBehaviour : MonoBehaviour
{
    #region ACExec()
    /// <summary>
    /// Executes the function on the next frame.
    /// "ACExecNextFrame( () => {func} )"
    /// </summary>
    /// <param name="func">Function to execute</param>
    protected void ACExecNextFrame(Action func)
    {
        StartCoroutine(ExecAfterFrames(1, func));
    }
    /// <summary>
    /// Executes the function after X frames. "ACExecNextFrame( frames, () => {func} )"
    /// </summary>
    /// <param name="frames">Number of frames to wait</param>
    /// <param name="func">Function to execute</param>
    protected void ACExecAfterFrames(int frames, Action func)
    {
        StartCoroutine(ExecAfterFrames(frames, func));
    }
    /// <summary>
    /// Executes the function after X seconds.
    /// </summary>
    /// <param name="seconds">Number of seconds to wait.</param>
    /// <param name="func">Function to execute</param>
    protected void ExecuteAfterSeconds(float seconds, Action func)
    {
        if (seconds <= 0f)
            func();
        else
            StartCoroutine(ExecAfterSeconds(seconds, func));
    }

    #region ACExec() Coroutines
    private IEnumerator ExecAfterFrames(int frames, Action func)
    {
        for (int f = 0; f < frames; f++)
            yield return new WaitForEndOfFrame();
        func();
    }
    private IEnumerator ExecAfterSeconds(float seconds, Action func)
    {
        yield return new WaitForSeconds(seconds);
        func();
    }
    #endregion ACExec() Coroutines

    #endregion ACExec()

    #region DoTween

    /// <summary>
    /// Grows or Shrinks the Target towards the desired Scale over time. Useful for UI.
    /// </summary>
    /// <param name="rect">Target RectTransform (NOT Transform)</param>
    /// <param name="scale">Target scale to adjust towards</param>
    /// <param name="time">Seconds to take to reach target scale</param>
    public void ACDoScale(RectTransform rect, float scale, float time, bool unscaledTime = false) => rect.DOScale(scale, time).SetUpdate(unscaledTime);

    /// <summary>
    /// Grows or Shrinks the Target towards the desired Scale over time. Useful for UI.
    /// </summary>
    /// <param name="obj">Target GameObject with RectTransform component (NOT Transform)</param>
    /// <param name="scale">Target scale to adjust towards</param>
    /// <param name="time">Seconds to take to reach target scale</param>
    public void ACDoScale(GameObject obj, float scale, float time, bool unscaledTime = false) => ACDoScale(obj.GetComponent<RectTransform>(), scale, time, unscaledTime);

    #endregion DoTween
}

#region Code to make this script visible to others
public class ACBehaviour<T> : ACBehaviour where T : ACBehaviour
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("ACBehaviour<" + typeof(T).ToString() + "> not instantiated!\nNeed to call Instantiate() from " + typeof(T).ToString() + "Awake().");
            return _instance;
        }
    }

    // Instantiate singleton
    protected bool Instantiate()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Instance of ACBehaviour<" + typeof(T).ToString() + "> already exists! Destroying myself.\nIf you see this when a scene is LOADED from another one, ignore it.");
            DestroyImmediate(gameObject);
            return false;
        }
        _instance = this as T;
        return true;
    }
}
#endregion Code to make this script visible to others
