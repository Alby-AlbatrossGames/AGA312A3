using DG.Tweening;
using TMPro;
using UnityEngine;

public class VDoorAnimator : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject closedPos;
    [SerializeField] private GameObject openPos;
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
    private void OpenDoors()
    {
        isOpen = true;
        door.gameObject.transform.DOMove(openPos.transform.position, duration);
    }

    private void CloseDoors()
    {
        isOpen = false;
        door.gameObject.transform.DOMove(closedPos.transform.position, duration);
    }
}
