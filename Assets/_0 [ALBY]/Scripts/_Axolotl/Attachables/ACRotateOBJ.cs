using UnityEngine;

public class ACRotateOBJ : MonoBehaviour
{
    public Vector3 _vector;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_vector * Time.deltaTime);
    }
}
