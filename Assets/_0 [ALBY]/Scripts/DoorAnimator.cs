using DG.Tweening;
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

    public void ToggleDoors()
    {
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
}
