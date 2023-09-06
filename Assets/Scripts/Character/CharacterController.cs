using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Componente usado para controlar varias cosas del player
/// </summary>
public class CharacterController : MonoBehaviour {

	#region Public variables
	public GameObject zoneArm;
	[HideInInspector] public CameraInteraction cameraInteraction;
	[HideInInspector] public CharacterAudios audios;
	#endregion

	#region Private variables
	private FirstPersonController player;
	#endregion

	void Awake() {
		player				= this.GetComponent<FirstPersonController>();
		audios				= this.GetComponent<CharacterAudios>();
		cameraInteraction	= this.GetComponentInChildren<CameraInteraction>();
	}

	#region Public Methods
	public void Kill(Transform target){
		player.playerCanMove = false;
		player.cameraCanMove = false;
		this.transform.LookAt(target);
	}
	#endregion
}
