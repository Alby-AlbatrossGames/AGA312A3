using UnityEngine;
using UnityEngine.Events;

public class LightToggle : MonoBehaviour
{
    public Light A1;
    public Light A2;
    public Light A3;
    public Light A4;

    public bool isUnlocked = false;
    public UnityEvent onUnlock;

    public void GreenLight()
    {
        if (isUnlocked ) { return; }
        A1.color = Color.green;
        A2.color = Color.green;
        A3.color = Color.green;
        A4.color = Color.green;
        isUnlocked = true;
        onUnlock.Invoke();
    }
    public void RedLight()
    {
        A1.color = Color.red;
        A2.color = Color.red;
        A3.color = Color.red;
        A4.color = Color.red;
    }
}
