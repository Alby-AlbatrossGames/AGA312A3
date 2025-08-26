using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputIndicator : MonoBehaviour
{
    public KeyCode key;

    private Image buttonImg;
    private TMP_Text buttonLabel;
    private bool isPressed;
    private bool hasReleased;
    private Color clrReleased;
    private Color clrPressed = Color.green;
    private Color txtReleased;
    private Color txtPressed = Color.lawnGreen;
    private void Start()
    {
        buttonImg = GetComponent<Image>();
        if (buttonImg != null) clrReleased = buttonImg.color;
        buttonLabel = GetComponentInChildren<TMP_Text>();
        if (txtReleased != null) txtReleased = buttonLabel.color;
        buttonLabel.text = key.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            PressKey();
        }else if (Input.GetKeyUp(key))
        {
            ReleaseKey();
        }
    }
    public void PressKey()
    {
        isPressed = true;
        if (buttonImg != null) buttonImg.color = clrPressed;
        if (buttonLabel != null) buttonLabel.color = txtPressed;
        
        
    }
    private void ReleaseKey()
    {
        isPressed = false;
        if (buttonImg != null) buttonImg.color = clrReleased;
        if (buttonLabel != null) buttonLabel.color = txtReleased;
    }
}
