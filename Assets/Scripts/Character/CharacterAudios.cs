using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

/// <summary>
/// Controla los audios usados por el personaje
/// </summary>
public class CharacterAudios : MonoBehaviour {
	#region Class references
	private FirstPersonController _character;
	#endregion

	#region Fmod sounds
	[SerializeField] private EventReference _step;
	#endregion

	void Awake() {
		_character = this.GetComponent<FirstPersonController>();
	}

	void Start() {
		_character.OnStep.AddListener(()=>PlayStep());
	}

	#region Private Methods
	private void PlayStep() => RuntimeManager.PlayOneShot(_step, this.transform.position);
	#endregion
}
