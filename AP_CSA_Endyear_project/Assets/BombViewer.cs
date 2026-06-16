using UnityEngine;
using UnityEngine.InputSystem;

public class BombViewer : MonoBehaviour
{
    public Transform target;

    [Header("Orbit")]
    public float rotationSpeed = 90f;

    [Header("Zoom")]
    public float distance = 500f;
    private float targetDistance;

    public float zoomStep = 50f;
    public float zoomSmoothness = 8f;

    public float minDistance = 300f;
    public float maxDistance = 1000f;

    [Header("Vertical Rotation")]
    public float verticalAngle = 20f;
    public float verticalSpeed = 60f;
    public float minVerticalAngle = 0f;
    public float maxVerticalAngle = 90f;

    private float horizontalAngle = 0f;

    void Start()
    {
        targetDistance = distance;
        UpdateCameraPosition();
    }

    void Update()
    {
        if (target == null || Keyboard.current == null)
            return;

        // Horizontal rotation
        if (Keyboard.current.leftArrowKey.isPressed)
            horizontalAngle -= rotationSpeed * Time.deltaTime;

        if (Keyboard.current.rightArrowKey.isPressed)
            horizontalAngle += rotationSpeed * Time.deltaTime;

        // Vertical rotation
        if (Keyboard.current.upArrowKey.isPressed)
            verticalAngle += verticalSpeed * Time.deltaTime;

        if (Keyboard.current.downArrowKey.isPressed)
            verticalAngle -= verticalSpeed * Time.deltaTime;

        // Chunk zoom with easing
        if (Keyboard.current.iKey.wasPressedThisFrame)
            targetDistance -= zoomStep;

        if (Keyboard.current.oKey.wasPressedThisFrame)
            targetDistance += zoomStep;

        targetDistance = Mathf.Clamp(
            targetDistance,
            minDistance,
            maxDistance
        );

        distance = Mathf.Lerp(
            distance,
            targetDistance,
            zoomSmoothness * Time.deltaTime
        );

        verticalAngle = Mathf.Clamp(
            verticalAngle,
            minVerticalAngle,
            maxVerticalAngle
        );

        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        float hRad = horizontalAngle * Mathf.Deg2Rad;
        float vRad = verticalAngle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            Mathf.Sin(hRad) * Mathf.Cos(vRad),
            Mathf.Sin(vRad),
            Mathf.Cos(hRad) * Mathf.Cos(vRad)
        ) * distance;

        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}