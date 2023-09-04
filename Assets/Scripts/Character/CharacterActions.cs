using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Componente usado para controlar varias cosas del player
/// </summary>
public class CharacterActions : MonoBehaviour {
	
	private FirstPersonController player;

	void Awake() {
		player = this.GetComponent<FirstPersonController>();
	}

	#region Public Methods
	public void Kill(Transform target){
		player.playerCanMove = false;
		player.cameraCanMove = false;
		this.transform.LookAt(target);
	}
	#endregion
}
