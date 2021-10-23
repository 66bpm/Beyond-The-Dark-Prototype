using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }
    public Vector3 AimDirectionInput { get; private set; }
    public bool AimInput { get; private set; }
    public bool AttackInput { get; private set; }
    public bool SneakInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpHoldInput { get; private set; }
    public bool CanMove { get; private set; }
    public bool CanControl { get; set; }

    UnityEngine.InputSystem.PlayerInput controls;
    public static ControlDeviceType currentControlDevice;
    public enum ControlDeviceType
    {
        KeyboardAndMouse,
        Gamepad,
    }

    [SerializeField] private float jumpBufferLength = 0.2f;
    private float jumpBufferStartTime;
    [SerializeField] private float attackBufferLength = 0.2f;
    private float attackBufferStartTime;

    private void Start()
    {
        CanMove = true;
        CanControl = true;
        controls = GetComponent<UnityEngine.InputSystem.PlayerInput>();
        controls.onControlsChanged += OnControlsChanged;
    }

    private void Update()
    {
        CheckJumpInputBuffer();
        CheckAttackInputBuffer();
        Debug.DrawRay(transform.position, AimDirectionInput, Color.green);

    }

    private void OnControlsChanged(UnityEngine.InputSystem.PlayerInput obj)
    {
        if (obj.currentControlScheme == "Gamepad")
        {
            if (currentControlDevice != ControlDeviceType.Gamepad)
            {
                currentControlDevice = ControlDeviceType.Gamepad;
            }
        }
        else
        {
            if (currentControlDevice != ControlDeviceType.KeyboardAndMouse)
            {
                currentControlDevice = ControlDeviceType.KeyboardAndMouse;
            }
        }
    }

    public void OnMoveInput (InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>().normalized;
    }
    public void OnAimDirectionInput (InputAction.CallbackContext context)
    {
        if (currentControlDevice == ControlDeviceType.KeyboardAndMouse)
        {
            Vector3 mouseScreenPosition = context.ReadValue<Vector2>();
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseScreenPosition.z = 0f;
            AimDirectionInput = (mouseWorldPosition - transform.position).normalized;
        }
        else
        {
            AimDirectionInput = context.ReadValue<Vector2>().normalized;
            if (AimDirectionInput != Vector3.zero) AimInput = true;
            else AimInput = false;
        }
    }

    public void OnAimInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AimInput = true;
        }
        if (context.canceled)
        {
            AimInput = false;
        }
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

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
            attackBufferStartTime = Time.time;
        }
    }

    public void UseAttackInput() => AttackInput = false;
    private void CheckAttackInputBuffer()
    {
        if (Time.time > attackBufferStartTime + attackBufferLength)
        {
            AttackInput = false;
        }
    }

    public Vector2 GetAttackDirection(bool isFacingRight)
    {
        if (currentControlDevice == ControlDeviceType.Gamepad)
        {
            if (AimDirectionInput == Vector3.zero)
            {
                if (isFacingRight) return Vector2.right;
                else return Vector2.left;
            }
        }
        float angle = Mathf.Atan2(AimDirectionInput.y, AimDirectionInput.x) * Mathf.Rad2Deg;
        if (angle >= -45f && angle < 45f)
        {
            return Vector2.right;
        }
        else if (angle >= 45f && angle < 135f)
        {
            return Vector2.up;
        }
        else if (angle >= -135f && angle < -45f)
        {
            return Vector2.down;
        }
        else return Vector2.left;
    }

    public IEnumerator DisableMovement(float time)
    {
        CanMove = false;
        yield return new WaitForSeconds(time);
        CanMove = true;
    }

    public IEnumerator DisableControl(float time)
    {
        CanControl = false;
        yield return new WaitForSeconds(time);
        CanControl = true;
    }
}
