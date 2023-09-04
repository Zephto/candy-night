using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class EnemyAudios : MonoBehaviour {
	#region Fmod sounds
	[SerializeField] private EventReference scream;
	#endregion

	#region Public Methods
	public void PlayScream() => RuntimeManager.PlayOneShot(scream, this.transform.position);
	#endregion
}
