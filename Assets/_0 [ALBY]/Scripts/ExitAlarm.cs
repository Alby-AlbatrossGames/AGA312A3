using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ExitAlarm : MonoBehaviour
{
    public float spacing = 0.7f;
    public UnityEvent onLightsOn;
    public UnityEvent onLightsOff;

    private void OnEnable() => StartCoroutine(LightsOff());

    private IEnumerator LightsOn()
    {
        onLightsOn.Invoke();
        yield return new WaitForSeconds(spacing);
        StartCoroutine(LightsOff());
    }
    private IEnumerator LightsOff()
    {
        onLightsOff.Invoke();
        yield return new WaitForSeconds(spacing);
        StartCoroutine(LightsOn());
    }
}
