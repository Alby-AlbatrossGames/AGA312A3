using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ACTextPopup : MonoBehaviour
{
    [SerializeField] public GameObject popup;
    [SerializeField] public KeyCode actionKey;
    [SerializeField] public UnityEvent onPressAction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popup.SetActive(true);
            GlobalEvents.ReportToggleInteract();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popup.SetActive(false);
            GlobalEvents.ReportToggleInteract();
        }
    }
}
