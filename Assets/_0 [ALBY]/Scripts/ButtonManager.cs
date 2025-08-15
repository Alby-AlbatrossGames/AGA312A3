using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour
{
    public List<GameObject> buttons = new List<GameObject>();
    public void HideAllButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            HideButton(buttons[i], 0.2f * i);
        }
    }

    private IEnumerator HideButton(GameObject btn, float sec)
    {
        yield return new WaitForSeconds(sec);
        btn.transform.DOBlendableLocalMoveBy(new Vector3(-(Screen.width / 2), 0, 0), 0.5f);
    }
}
