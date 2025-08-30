using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Piston : MonoBehaviour
{
    public float outVal;
    public float inVal;
    public float duration = 1;
    public float delay = 0.5f;
    public Ease pistonEase;
    public UnityEvent OnMoveOutComplete;
    public UnityEvent OnMoveInComplete;
    private Transform piston;
    public bool isOut;
    public bool isMoving = false;
    public UnityEvent OnMoveSTART;
    public UnityEvent OnMoveEND;
    void Start()
    {
        piston = GetComponentInChildren<Transform>();
    }

    public void Activate()
    {
        switch (isOut)
        {
            case true: MoveIn(); break;
            case false: MoveOut(); break;
        }
    }

    private void MovePiston(float _end, float _dur = 1f)
    {
        isMoving = true;
        OnMoveSTART.Invoke();
        piston.transform.DOLocalMoveY(_end, _dur).SetEase(pistonEase).OnComplete(() => OnMoveComplete());
    }
    private void OnMoveComplete()
    {
        isMoving = false;
        OnMoveEND.Invoke();
        isOut = !isOut;
        StartCoroutine(DelayedStart());
    }
    private IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(delay);
        switch (isOut)
        {
            case true: OnMoveOutComplete.Invoke(); break;
            case false: OnMoveInComplete.Invoke(); break;
        }
    }

    public void MoveOut()
    {
        MovePiston(outVal, duration);
    }
    public void MoveIn()
    {
        MovePiston(inVal, duration);
    }
}
