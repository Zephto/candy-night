using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Componente usado para oscilar la camara del menu
/// </summary>
public class OscilationCamera : MonoBehaviour
{
	public float amplitude = 20f;
	public float velocity = 0.5f;
	private Vector3 initialPosition;

	void Start() {
		initialPosition = transform.localEulerAngles;

		StartCoroutine(OscilarCamara());
	}

	IEnumerator OscilarCamara()
	{
		while (true)
		{
			float newY = initialPosition.y + Mathf.Sin(Time.time * velocity) * amplitude;
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newY, transform.localEulerAngles.z);
			yield return null;
		}
	}
}
