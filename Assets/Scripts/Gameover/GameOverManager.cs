using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Componente para controlar el gameover
/// </summary>
public class GameOverManager : MonoBehaviour {
	#region Public variables
	[SerializeField] private Button TryAgainButton;
	[SerializeField] private Button menuButton;

	[Header("Audios reference")]
	[SerializeField] private SpatialSoundTrigger selection;
	#endregion

	void Start() {
		TryAgainButton.onClick.AddListener(()=> StartCoroutine(GoToGame()));
		menuButton.onClick.AddListener(()=> StartCoroutine(GoToMenu()));
		Cursor.lockState = CursorLockMode.None;
	}

	private IEnumerator GoToGame(){
		selection.Play();

		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadSceneAsync("CandyShop");
	}

	private IEnumerator GoToMenu(){
		selection.Play();

		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadSceneAsync("MainMenu");
	}
}
