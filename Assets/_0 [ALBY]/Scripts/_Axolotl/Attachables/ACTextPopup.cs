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
        if (other.CompareTag("Player")) popup.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) popup.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(actionKey))
            {
                onPressAction.Invoke();
            }
        }
    }
}
