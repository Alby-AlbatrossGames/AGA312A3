using UnityEngine;

public class LightToggle : MonoBehaviour
{
    public Light A1;
    public Light A2;
    public Light A3;
    public Light A4;

    public void GreenLight()
    {
        A1.color = Color.green;
        A2.color = Color.green;
        A3.color = Color.green;
        A4.color = Color.green;
    }
    public void RedLight()
    {
        A1.color = Color.red;
        A2.color = Color.red;
        A3.color = Color.red;
        A4.color = Color.red;
    }
}
