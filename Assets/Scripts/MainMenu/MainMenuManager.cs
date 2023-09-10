using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Componente que controla el menu principal
/// </summary>
public class MainMenuManager : MonoBehaviour {

	#region Public variables
	[Header("Buttons reference")]
	[SerializeField] private Button startGameButton;
	[SerializeField] private Button creditsButton;
	[SerializeField] private Button exitButton;
	
	[Header("Audios reference")]
	[SerializeField] private SpatialSound music;
	[SerializeField] private SpatialSoundTrigger selection;

	[Header("Audios reference")]
	[SerializeField] private LightsEmergencyBehaviour emergencyLight;

	#endregion

	void Start() {
		startGameButton.onClick.AddListener(()=> StartCoroutine(StartGame()));
		creditsButton.onClick.AddListener(()=>StartCoroutine(GoToCredits()));
		exitButton.onClick.AddListener(()=>StartCoroutine(ExitGame()));

		emergencyLight.TurnOn();
	}

	#region Private Methods
	private IEnumerator StartGame(){
		selection.Play();
		music.Stop();

		yield return new WaitForSeconds(1f);
		SceneManager.LoadSceneAsync("CandyShop");
	}

	private IEnumerator GoToCredits(){
		selection.Play();

		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadSceneAsync("Credits");
	}

	private IEnumerator ExitGame(){
		selection.Play();

		yield return new WaitForSeconds(0.5f);
		Application.Quit();
	}
	#endregion
}
