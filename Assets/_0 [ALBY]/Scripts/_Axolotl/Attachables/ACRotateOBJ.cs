using UnityEngine;

public class ACRotateOBJ : MonoBehaviour
{
    public Vector3 _vector;
    public bool canSpin = false;

    // Update is called once per frame
    void Update()
    {
        if (canSpin) transform.Rotate(_vector * Time.deltaTime);
    }

    public void Activate() => canSpin = true;
}
