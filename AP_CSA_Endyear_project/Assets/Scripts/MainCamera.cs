using UnityEngine;
using UnityEngine.InputSystem;

public class MainCamera : MonoBehaviour
{
    public float sensitivity = 10f;

    private PlayerControls controls;
    private Vector2 lookInput;
    private float xRotation = 0f;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Look.performed +=
            ctx => lookInput = ctx.ReadValue<Vector2>();

        controls.Player.Look.canceled +=
            ctx => lookInput = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = lookInput.x * sensitivity;
        float mouseY = lookInput.y * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation =
            Quaternion.Euler(xRotation, 0f, 0f);

        if (transform.parent != null)
        {
            transform.parent.Rotate(Vector3.up * mouseX);
        }
    }
}