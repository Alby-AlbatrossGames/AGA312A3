using System;

public class GlobalEvents
{
    public static event Action ToggleInteract = null;

    public static void ReportToggleInteract() => ToggleInteract?.Invoke();
}
