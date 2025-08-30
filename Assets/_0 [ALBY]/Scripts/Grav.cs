using UnityEngine;

public class Grav : MonoBehaviour
{
    public Rigidbody rb;
    public bool isLowGrav = false;
    private float lowGravMass = 35f;
    private float normalMass = 50f;

    public void ToggleMass()
    {
        switch (isLowGrav)
        {
            case true: rb.mass = lowGravMass; break;
            case false: rb.mass = normalMass; break;
        }
    }
}
