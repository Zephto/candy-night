using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Componente usado para controlar las luces
/// </summary>
public class LightsBehaviour : MonoBehaviour {
	#region Public references
	[SerializeField] private Material normalLights;
	[SerializeField] private Material damageLights;
	[SerializeField] private GameObject lightReference;
	#endregion
	
	#region private references
	private SpatialSound spatialSoundRef;
	private MeshRenderer meshRenderer;
	#endregion

	void Awake() {
		spatialSoundRef = this.GetComponent<SpatialSound>();
		meshRenderer = this.GetComponent<MeshRenderer>();
	}

	#region Public Methods
	public void TurnOn(){
		spatialSoundRef.enabled = true;
		meshRenderer.material = normalLights;
		lightReference.SetActive(true);
	}

	public void TurnOff(){
		spatialSoundRef.enabled = false;
		meshRenderer.material = damageLights;
		lightReference.SetActive(false);
	}
	#endregion
}
