using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 
/// </summary>
public class MouseLook : MonoBehaviour
{
	#region Public variables
	private float mouseSensivity = 100f;
	#endregion

	#region Private variables
	private Transform playerBody;
	private PlayerInput controls;
	private Vector2 mouseInput;
	private float mouseX;
	private float mouseY;
	private float xRotation = 0f;
	#endregion

	void Awake() {
		playerBody = this.transform.parent;
		controls = new PlayerInput();
	}

	void Start() {
		controls.Enable();
	}

	void OnDestroy() {
		controls.Disable();
	}

	void Update() {
		mouseInput = controls.Player.Aim.ReadValue<Vector2>();
		mouseX = mouseInput.x * mouseSensivity * Time.deltaTime;
		mouseY = mouseInput.y * mouseSensivity * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90);

		this.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}
}
