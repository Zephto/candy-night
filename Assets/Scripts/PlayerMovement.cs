using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private PlayerInput controls;
    private Rigidbody rb;

    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerInput();
        controls.Enable();
    }

    void OnDestroy() {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // input = playerInput.actions["Move"].ReadValue<Vector2>();
        input = controls.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {

        var movement = (input.y * this.transform.forward) + (input.x * this.transform.right);
        // rb.AddForce(new Vector3(input.x, 0f, input.y) * Speed);
        rb.AddForce(movement * Speed);
    }

}
