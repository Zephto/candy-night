using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

/// <summary>
/// Componente usado para reproducir constantemente el efecto de luces
/// </summary>
public class SpatialSoundTrigger : MonoBehaviour {
	#region Fmod sounds
	[SerializeField] private EventReference audioReference;
	#endregion

	#region Public Methods
	public void Play() => RuntimeManager.PlayOneShot(audioReference, this.transform.position);
	#endregion
}
