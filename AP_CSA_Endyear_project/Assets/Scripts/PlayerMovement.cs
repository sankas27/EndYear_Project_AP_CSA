using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private CharacterController controller;
    private PlayerControls controls;
    private Vector2 moveInput;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        controls = new PlayerControls();

        controls.Player.Move.performed +=
            ctx => moveInput = ctx.ReadValue<Vector2>();

        controls.Player.Move.canceled +=
            ctx => moveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        Vector3 move =
            transform.right * moveInput.x +
            transform.forward * moveInput.y;

        controller.Move(move * speed * Time.deltaTime);
    }
}