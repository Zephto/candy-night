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

	#region Private variables
	private int currentTension = 0;
	#endregion

	void Start() {
		ambientSoundInstance = RuntimeManager.CreateInstance(ambientSound);
		ambientSoundInstance.start();
		currentTension = tension = 0;
	}

	void OnDestroy() {
		ambientSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	void Update() {
		if(tension != currentTension){
			currentTension = tension;
			ambientSoundInstance.setParameterByName("tension", currentTension);

		}
	}
}
