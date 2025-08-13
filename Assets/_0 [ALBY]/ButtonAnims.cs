using UnityEngine;
using AllIn1SpringsToolkit;
using DG.Tweening;

public class ButtonAnims : MonoBehaviour
{
    private RectTransform c_RectTransform;
    private Vector3 d_Size;

    private void Awake()
    {
        c_RectTransform = GetComponent<RectTransform>();
        d_Size = new Vector3(c_RectTransform.rect.x, c_RectTransform.rect.y, 1);
    }

    public void GrowButton()
    {
        c_RectTransform.DOScale(1.2f, 0.3f).OnComplete(() => Debug.Log("Grow: "+c_RectTransform.transform.localScale));
    }

    public void ShrinkButton()
    {
        c_RectTransform.DOScale(1, 0.3f).OnComplete(() => Debug.Log("Shrink: "+c_RectTransform.transform.localScale));
    }
}
