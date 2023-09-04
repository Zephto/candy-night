using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

/// <summary>
/// Componente que controla y reproduce el sonido de ambiente
/// </summary>
public class AudioAmbience : MonoBehaviour {
	[Range(0, 2)]
	public int tension = 0;
	
	#region Fmod sounds
	[SerializeField] private EventReference ambientSound;
	private EventInstance ambientSoundInstance;
	#endregion

	void Start() {
		ambientSoundInstance = RuntimeManager.CreateInstance(ambientSound);
		ambientSoundInstance.start();
	}
}
