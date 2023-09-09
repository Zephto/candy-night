using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Componente usado para saber si el usuario toco con la salida
/// </summary>
public class ExitDetector : MonoBehaviour
{
	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")){
			Debug.Log("Si toy triguereando");
			GameManager.Instance.FinishGame();
		}
	}
}
