using UnityEngine;

public class ACLookAt : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private bool lookAtTarget = true;
    private void Update()
    {
        if (lookAtTarget) { transform.LookAt(target.transform.position); };
    }
    
}
