using UnityEngine;
using AllIn1SpringsToolkit;
using DG.Tweening;

public class ButtonAnims : MonoBehaviour
{
    private RectTransform c_RectTransform;

    private void Awake() => c_RectTransform = GetComponent<RectTransform>();

    public void GrowButton() => c_RectTransform.DOScale(1.2f, 0.3f);

    public void ShrinkButton() => c_RectTransform.DOScale(1, 0.3f);
}
