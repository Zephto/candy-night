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
	[SerializeField] private EventReference step;
	[SerializeField] private EventReference grab;
	[SerializeField] private EventReference breathing;
	private EventInstance breathingInstance;
	private bool isBreathingPlay = false;
	#endregion

	void Awake() {
		_character = this.GetComponent<FirstPersonController>();
	}

	void Start() {
		_character.OnStep.AddListener(()=>PlayStep());
		_character.OnSprint.AddListener((value)=>PlayBreathing(value));

		//breathing instance
		breathingInstance = RuntimeManager.CreateInstance(breathing);
		//breathingInstance.set3DAttributes(RuntimeUtils.To3DAttributes(this.gameObject));
		isBreathingPlay = false;
	}

	void OnDestroy() {
		breathingInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}

	void Update() {
		breathingInstance.set3DAttributes(RuntimeUtils.To3DAttributes(this.gameObject));
	}

	#region Public Methods
	public void PlayStep() => RuntimeManager.PlayOneShot(step, this.transform.position);
	public void PlayGrab() => RuntimeManager.PlayOneShot(grab, this.transform.position);

	public void PlayBreathing(bool isSprinting){
		
		if(isSprinting && isBreathingPlay == false){
			breathingInstance.setParameterByName("isSprint", 0);
			breathingInstance.start();
			isBreathingPlay = true;
		}else{
			breathingInstance.setParameterByName("isSprint", 1);
			isBreathingPlay = false;
		}
	}
	#endregion
}
