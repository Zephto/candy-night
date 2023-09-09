using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Componente usado para controlar la puerta principal
/// </summary>
public class MainDoor : MonoBehaviour {
	
	#region Public variables
	[SerializeField] private GameObject rightDoor;
	[SerializeField] private GameObject leftDoor;
	#endregion

	#region Private variables
	private float closeSpeed = 6f;
	private float openSpeed = 25f;
	#endregion

	public void CloseDoors(){
		StartCoroutine(OpenMovement(rightDoor.transform, 0, closeSpeed));
		StartCoroutine(OpenMovement(leftDoor.transform, 180, closeSpeed));
	}

	public void OpenDoors(){
		StartCoroutine(OpenMovement(rightDoor.transform, -130, openSpeed));
		StartCoroutine(OpenMovement(leftDoor.transform, 300, openSpeed));
	}

	#region Coroutines
	public IEnumerator OpenMovement(Transform door, float targetAngle, float rotationSpeed){
		
		while (Quaternion.Angle(door.localRotation, Quaternion.Euler(0f, targetAngle, 0f)) > 0.1f)
        {
            door.localRotation = Quaternion.RotateTowards(door.localRotation, Quaternion.Euler(0f, targetAngle, 0f), rotationSpeed * Time.deltaTime);
            yield return null;
        }

        door.localRotation = Quaternion.Euler(0f, targetAngle, 0f);
	}
	#endregion
}
