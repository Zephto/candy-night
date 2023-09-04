using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class EnemyAudios : MonoBehaviour {
	#region Fmod sounds
	[SerializeField] private EventReference scream;
	[SerializeField] private EventReference step;
	#endregion

	#region Public Methods
	public void PlayScream() => RuntimeManager.PlayOneShot(scream, this.transform.position);
	public void PlaySteps() => RuntimeManager.PlayOneShot(step, this.transform.position);
	#endregion
}
