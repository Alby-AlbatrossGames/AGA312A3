using System.Transactions;
using UnityEngine;
using UnityEngine.Events;

public class Footsteps : MonoBehaviour
{
    public UnityEvent OnStart;
    public UnityEvent OnMoving;
    public UnityEvent OnIdle;

    private void Start()
    {
        OnStart.Invoke();
    }
    private void Update()
    {
        if ( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ) { OnMoving.Invoke(); }
        else { OnIdle.Invoke(); }
    }
}
