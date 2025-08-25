using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HackablePipes : MonoBehaviour
{
    private bool isEnabled = false;
    public UnityEvent OnEnabled;
    public Light L1;
    [Header("Popup Text")]
    public TMP_Text popup;
    public TMP_Text key;

    public void Hack()
    {
        if (isEnabled) return;

        isEnabled = true;
        OnEnabled.Invoke();
        L1.color = Color.green;
        popup.text = "Active";
        key.color = Color.red;
    }
}
