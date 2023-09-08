using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// Componente usado para controlar las luces
/// </summary>
public class LightsEmergencyBehaviour : MonoBehaviour {
	#region Public references
	[SerializeField] private Material normalLights;
	[SerializeField] private Material damageLights;
	[SerializeField] private Light lightReference;
	#endregion
	
	#region private references
	private SpatialSound spatialSoundRef;
	private MeshRenderer meshRenderer;
	private float intensityRef;
	private bool isOn;
	#endregion

	void Awake() {
		spatialSoundRef = this.GetComponent<SpatialSound>();
		meshRenderer = this.GetComponent<MeshRenderer>();
	}

	void Start() {
		intensityRef = lightReference.intensity;
		isOn = false;
	}

	#region Public Methods
	public void TurnOn(){
		spatialSoundRef.enabled = true;
		meshRenderer.material = normalLights;
		lightReference.gameObject.SetActive(true);
		isOn = true;
	}

	public void TurnOff(){
		spatialSoundRef.enabled = false;
		meshRenderer.material = damageLights;
		lightReference.gameObject.SetActive(false);
		isOn = false;
		Debug.Log("APAGA EMERGENICA");
	}
	#endregion

	void Update() {
		if(isOn){
			var time = Mathf.PingPong(Time.time * 0.3f, 1f);
			lightReference.intensity = Mathf.Lerp(0f, intensityRef, time);
		}
	}
}
