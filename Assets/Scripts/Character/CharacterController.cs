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
		zoneArm.SetActive(false);
		this.transform.LookAt(target);
		StartCoroutine(ShakeCamera());
		GameManager.Instance.StopPinatas();
	}
	#endregion

	#region Private Methods
	private IEnumerator ShakeCamera(){
		float currentTime = 0f;
		float shakeDuration = 3f;
		float shakeMagnitude = 0.05f;

		Vector3 camOriginalPosition = Camera.main.transform.localPosition;

		while(currentTime < shakeDuration){
			Vector3 randomShake = Random.insideUnitCircle * shakeMagnitude;
			Camera.main.transform.localPosition = camOriginalPosition + randomShake;
		
			currentTime += Time.deltaTime;
			yield return null;
		}

		Camera.main.transform.localPosition = camOriginalPosition;
	}
	#endregion
}
