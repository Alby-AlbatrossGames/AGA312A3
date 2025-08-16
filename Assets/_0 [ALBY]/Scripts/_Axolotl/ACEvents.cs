using System;
using UnityEngine;

public class ACEvents : ACBehaviour
{
    public static event Action OnPauseButtonPress = null;
    public static void ReportOnPauseButtonPress() => OnPauseButtonPress?.Invoke();
}
