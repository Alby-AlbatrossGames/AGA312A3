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
    public bool isOpen = false;
    [Header("Core")]
    public bool isLockedA = true;
    public bool isLockedB = true;
    public bool isUnlocked = false;
    public Light A1;
    public Light A2;
    public Light B1;
    public Light B2;
    [Header("Popup")]
    public TMP_Text popup;
    public TMP_Text key;

    private void Start() => UnlockDoor();
    public void ToggleDoorsOverride()
    {
        switch (isOpen)
        {
            case true: CloseDoors(); break;
            case false: OpenDoors(); break;
        }
    }
    public void ToggleDoors()
    {
        Debug.LogWarning("ToggleDoors Ran");
        if (!isUnlocked) return;
        Debug.LogWarning("isUnlocked = " + isUnlocked);
        switch (isOpen)
        {
            case true: CloseDoors(); break;
            case false: OpenDoors(); break;
        }
    }
    private void OpenDoors()
    {
        isOpen = true;
        doorLeft.gameObject.transform.DOMove(doorLeftOpenPos.transform.position, duration).SetEase(Ease.InExpo);
        doorRight.gameObject.transform.DOMove(doorRightOpenPos.transform.position, duration).SetEase(Ease.InExpo);
    }

    private void CloseDoors()
    {
        isOpen = false;
        doorLeft.gameObject.transform.DOMove(doorLeftClosedPos.transform.position, duration).SetEase(Ease.InExpo);
        doorRight.gameObject.transform.DOMove(doorRightClosedPos.transform.position, duration).SetEase(Ease.InExpo);
    }

    public void EnableDoor()
    {
        popup.text = "Interact";
        key.color = Color.green;
    }
    public void DisableDoor()
    {
        popup.text = "Locked";
        key.color = Color.red;
    }

    public void OpenLock(string _lock)
    {
        switch(_lock)
        {
            case "A":
                if (!isLockedA) return;
                isLockedA = false;
                A1.color = Color.green; 
                A2.color = Color.green;
                break;
            case "B":
                if (!isLockedB) return;
                isLockedB = false;
                B1.color = Color.green;
                B2.color = Color.green;
                break;
        }
        UnlockDoor();
    }
    public void UnlockDoor()
    {
        if (!isLockedA && !isLockedB)
        {
            EnableDoor();
            isUnlocked = true;
        }
        else
        {
            DisableDoor();
            isUnlocked = false;
        }
    }
    public void CloseLock(string _lock)
    {
        switch (_lock)
        {
            case "A":
                if (isLockedA) return;
                isLockedA = true;
                A1.color = Color.red;
                A2.color = Color.red;
                break;
            case "B":
                if (isLockedB) return;
                isLockedB = true;
                B1.color = Color.red;
                B2.color = Color.red;
                break;
        }
        UnlockDoor();
    }
}
