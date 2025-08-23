using DG.Tweening;
using TMPro;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    [SerializeField] private GameObject doorLeft;
    [SerializeField] private GameObject doorLeftClosedPos;
    [SerializeField] private GameObject doorLeftOpenPos;
    [SerializeField] private GameObject doorRight;
    [SerializeField] private GameObject doorRightClosedPos;
    [SerializeField] private GameObject doorRightOpenPos;
    [SerializeField] private float duration;
    private bool isOpen = false;
    [Header("Core")]
    public bool isLocked = true;
    public Light L1;
    public Light L2;
    public Light L3;
    public Light L4;
    [Header("Popup")]
    public TMP_Text popup;
    public TMP_Text key;

    public void ToggleDoors()
    {
        if (isLocked) return;

        switch (isOpen)
        {
            case true: CloseDoors(); break;
            case false: OpenDoors(); break;
        }
    }
    public void OpenDoors()
    {
        isOpen = true;
        doorLeft.gameObject.transform.DOMove(doorLeftOpenPos.transform.position, duration).SetEase(Ease.InExpo);
        doorRight.gameObject.transform.DOMove(doorRightOpenPos.transform.position, duration).SetEase(Ease.InExpo);
    }

    public void CloseDoors()
    {
        isOpen = false;
        doorLeft.gameObject.transform.DOMove(doorLeftClosedPos.transform.position, duration).SetEase(Ease.InExpo);
        doorRight.gameObject.transform.DOMove(doorRightClosedPos.transform.position, duration).SetEase(Ease.InExpo);
    }

    public void Unlock()
    {
        popup.text = "Interact";
        key.color = Color.green;

        isLocked = false;
        L1.color = Color.green;
        L2.color = Color.green;
        L3.color = Color.green;
        L4.color = Color.green;
    }
}
