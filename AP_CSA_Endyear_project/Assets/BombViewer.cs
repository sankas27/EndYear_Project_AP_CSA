using UnityEngine;

public class BombViewer : MonoBehaviour
{
    public Transform target;

    public float distance = 4f;
    public float height = 1.5f;
    public float rotationSpeed = 90f;

    private float currentAngle = 0f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("BombViewer: No target assigned!");
            return;
        }

        UpdateCameraPosition();
    }

    void Update()
    {
        float input = 0f;

        if (UnityEngine.InputSystem.Keyboard.current != null)
        {
            if (UnityEngine.InputSystem.Keyboard.current.leftArrowKey.isPressed)
                input = -1f;

            if (UnityEngine.InputSystem.Keyboard.current.rightArrowKey.isPressed)
                input = 1f;
        }

        currentAngle += input * rotationSpeed * Time.deltaTime;

        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        if (target == null) return;

        float radians = currentAngle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            Mathf.Sin(radians) * distance,
            height,
            Mathf.Cos(radians) * distance
        );

        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}