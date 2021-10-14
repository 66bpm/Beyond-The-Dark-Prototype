using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public bool SneakInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpHoldInput { get; private set; }
    public bool CanMove { get; private set; }
    public bool CanControl { get; set; }

    [SerializeField] private float jumpBufferLength = 0.2f;
    private float jumpBufferStartTime;
    private void Start()
    {
        CanMove = true;
        CanControl = true;
    }

    private void Update()
    {
        CheckJumpInputBuffer();
    }

    public void OnMoveInput (InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    public void OnSneakInput (InputAction.CallbackContext context)
    {
        SneakInput = context.performed;
    }

    public void OnJumpInput (InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpHoldInput = true;
            jumpBufferStartTime = Time.time;
        }
        if (context.canceled)
        {
            JumpHoldInput = false;
        }
    }

    public void UseJumpInput() => JumpInput = false;
    private void CheckJumpInputBuffer()
    {
        if (Time.time > jumpBufferStartTime + jumpBufferLength)
        {
            JumpInput = false;
        }
    }

    public IEnumerator DisableMovement(float time)
    {
        CanMove = false;
        yield return new WaitForSeconds(time);
        CanMove = true;
    }
}
