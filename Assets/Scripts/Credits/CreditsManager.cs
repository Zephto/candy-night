using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Componente usado para controlar los creditos
/// </summary>
public class CreditsManager : MonoBehaviour {
	
	#region Public variables
	[SerializeField] private CanvasGroup creditsGroup;
	[SerializeField] private Button returnToMenu;

	[Header("Audios reference")]
	[SerializeField] private SpatialSound music;
	[SerializeField] private SpatialSoundTrigger selection;
	#endregion

	void Start() {
		returnToMenu.onClick.AddListener(()=> StartCoroutine(GoToMenu()));

		returnToMenu.gameObject.SetActive(false);
		StartCoroutine(StartCredits());
		Cursor.lockState = CursorLockMode.None;
	}

	void OnDestroy() {
		LeanTween.cancel(this.gameObject);
	}

	private IEnumerator StartCredits(){
		LeanTween.value(creditsGroup.gameObject, 0f, 1f, 1f)
		.setOnUpdate((float value) => creditsGroup.alpha = value);

		yield return new WaitForSeconds(1.5f);
		LeanTween.moveLocalY(creditsGroup.gameObject, 4000, 60f);

		yield return new WaitForSeconds(3f);
		returnToMenu.gameObject.SetActive(true);
	}

	private IEnumerator GoToMenu(){
		selection.Play();
		music.Stop();

		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadSceneAsync("MainMenu");
	}
}
