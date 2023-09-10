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
	private EventInstance audioInstance;
	#endregion

	void Start() {
		audioInstance = RuntimeManager.CreateInstance(audioReference);
		audioInstance.set3DAttributes(RuntimeUtils.To3DAttributes(this.transform.position));
	}

	void OnDestroy() {
		audioInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	#region Public Methods
	public void Play() => audioInstance.start();

	public void Stop(){
		audioInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
	#endregion
}
