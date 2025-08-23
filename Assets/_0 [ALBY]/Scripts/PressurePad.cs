using DG.Tweening;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [Header("Main")]
    public GameObject mainButtonOBJ;
    public Light L1;
    public Light L2;
    [Header("Events")]
    public UnityEvent OnPressed;
    public UnityEvent OnReleased;
    [Header("Colours")]
    public Color activeLightClr;
    public Color inactiveLightClr;
    public Material activeBtnMat;
    public Material inactiveBtnMat;

    //private vars//
    private float activePos = -0.05f;    
    private float inactivePos = 0f;
    private Renderer mainBtn;

    private void Start() => mainBtn = mainButtonOBJ.GetComponent<Renderer>();
    public void OnActivate()
    {
        AnimatePad(activePos, activeLightClr, activeBtnMat);
        OnPressed.Invoke();
    }
    public void OnDeactivate()
    {
        AnimatePad(inactivePos, inactiveLightClr, inactiveBtnMat);
        OnReleased.Invoke();
    }

    void AnimatePad(float newPos, Color clr, Material mat) => mainButtonOBJ.transform.DOLocalMoveY(newPos, 0.3f).OnComplete(() => { ChangeLights(clr); ChangeMaterial(mat); });
    void ChangeLights(Color clr)
    {
        L1.color = clr;
        L2.color = clr;
    }
    void ChangeMaterial(Material mat) => mainBtn.material = mat;

    // ---------- Code below should be on a diff script --------//
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) OnActivate();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) OnDeactivate();
    }
}
