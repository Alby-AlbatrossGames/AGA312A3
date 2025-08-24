using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HackablePC : MonoBehaviour
{
    private bool isHacked = false;
    public UnityEvent OnHacked;
    public GameObject screen;
    public Material mat;
    public Light L1;
    [Header("Popup Text")]
    public TMP_Text popup;
    public TMP_Text key;

    public void Hack()
    {
        if (isHacked) return;

        isHacked = true;
        OnHacked.Invoke();
        screen.GetComponent<Renderer>().material = mat;
        L1.color = Color.green;
        popup.text = "Hacked";
        key.color = Color.red;
    }
}
