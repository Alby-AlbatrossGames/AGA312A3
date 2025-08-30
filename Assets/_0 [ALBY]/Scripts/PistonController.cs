using UnityEngine;
using UnityEngine.Events;

public class PistonController : MonoBehaviour
{
    public bool isActive = false;
    public UnityEvent OnActivated;

    public void Activate() { isActive = true; OnActivated.Invoke(); }
}
