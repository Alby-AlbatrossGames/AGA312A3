using Invector.vCharacterController;
using UnityEngine;

public class vChangeGrav : MonoBehaviour
{
    public vThirdPersonMotor baseScript;
    public float aJumpTimer;
    private float bJumpTimer = .3f;
    public float aJumpHeight;
    private float bJumpHeight = 4f;
    public float aAirSpeed;
    private float bAirSpeed = 5f;
    private void Start()
    {
        baseScript = FindFirstObjectByType<vThirdPersonMotor>();
    }

    public void AntiGrav() 
    { 
        baseScript.jumpTimer = aJumpTimer;
        baseScript.jumpHeight = aJumpHeight;
        baseScript.airSpeed = aAirSpeed;
    }
    public void BaseGrav() 
    { 
        baseScript.jumpTimer = bJumpTimer;
        baseScript.jumpHeight = bJumpHeight;
        baseScript.airSpeed = aAirSpeed;
    }
}
