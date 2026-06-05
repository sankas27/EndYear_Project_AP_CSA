using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
            move += Vector3.forward;

        if (Keyboard.current.sKey.isPressed)
            move += Vector3.back;

        if (Keyboard.current.aKey.isPressed)
            move += Vector3.left;

        if (Keyboard.current.dKey.isPressed)
            move += Vector3.right;



    if (Keyboard.current.wKey.isPressed)
    {
        Debug.Log("W PRESSED");
    }

        controller.Move(move.normalized * speed * Time.deltaTime);
    }
}