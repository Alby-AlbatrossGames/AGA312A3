using UnityEngine;
using UnityEngine.EventSystems;

public class ACFocusOnEnable : ACBehaviour
{
    // Attach this script to a UI GameObject (Button, etc) to apply focus when enabled.

    protected virtual void OnEnable() => EventSystem.current.SetSelectedGameObject(this.gameObject, null);
}
