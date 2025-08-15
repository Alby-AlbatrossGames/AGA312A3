using UnityEngine;

public class ACTransform : MonoBehaviour
{
    [Header("Rotation")]
    public bool applyRotation;
    public Vector3 rotationSpeed;
    [Header("Movement")]
    public bool applyMovement;
    public Vector3 movementSpeed;
    [Header("Time Scale")]
    public bool useUnscaledTime;

    private void Update()
    {
        switch (useUnscaledTime)
        {
            case false:
                RotateObj(Time.deltaTime);
                MoveObj(Time.deltaTime);
                break;
            case true:
                RotateObj(Time.unscaledDeltaTime);
                MoveObj(Time.unscaledDeltaTime);
                break;
        }
    }

    void RotateObj(float timeScale)
    {
        gameObject.transform.Rotate(rotationSpeed * timeScale);
    }
    void MoveObj(float timeScale)
    {
        gameObject.transform.Translate(movementSpeed * timeScale);
    }
}
