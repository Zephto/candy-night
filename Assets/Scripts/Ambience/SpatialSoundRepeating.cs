using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

/// <summary>
/// Componente usado para reproducir constantemente el efecto de luces
/// </summary>
public class SpatialSoundRepeating : MonoBehaviour {
	#region Fmod sounds
	[SerializeField] private EventReference audioReference;
	private EventInstance audioInstance;
	#endregion

	#region Private variables
	[SerializeField] private float repeatingTime = 1f;
	#endregion
	void Start() {
		InvokeRepeating("PlayThunder", repeatingTime, repeatingTime);
	}

	private void PlayThunder() => RuntimeManager.PlayOneShot(audioReference, this.transform.position);
}
