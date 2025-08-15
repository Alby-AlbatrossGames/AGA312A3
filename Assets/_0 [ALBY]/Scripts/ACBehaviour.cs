using UnityEngine;
using System;
using System.Collections;

public class ACBehaviour : MonoBehaviour
{
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
