using UnityEngine;
using UnityEngine.Events;

public class AutoTrigger : MonoBehaviour
{
    public UnityEvent onEnterTrigger;
    public UnityEvent onExitTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onEnterTrigger.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onExitTrigger.Invoke();
        }
    }
}
