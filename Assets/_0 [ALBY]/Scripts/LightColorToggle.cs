using UnityEngine;

public class LightColorToggle : MonoBehaviour
{
    private Transform lights;
    public Color cRed;
    public Color cGreen;
    public Color cBlue;

    private void Start()
    {
        lights = GetComponent<Transform>();
    }
    public void SetRed()
    {
        for (int i = 0; i < lights.transform.childCount; i++)
        {
            lights.transform.GetChild(i).gameObject.GetComponent<Light>().color = cRed;
        }
    }
    public void SetGreen()
    {
        for (int i = 0; i < lights.transform.childCount; i++)
        {
            lights.transform.GetChild(i).gameObject.GetComponent<Light>().color = cGreen;
        }
    }
    public void SetBlue()
    {
        for (int i = 0; i < lights.transform.childCount; i++)
        {
            Debug.Log(lights.transform.GetChild(i).gameObject.name);
            lights.transform.GetChild(i).gameObject.GetComponent<Light>().color = cBlue;
        }
    }
}
