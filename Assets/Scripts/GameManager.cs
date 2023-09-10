using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controlador principal del juego
/// </summary>
public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    #region Public variables
    [Header("General references")]
    public GameObject CamNota;
    public GameObject Player;
    public bool NotaStart = true;
    
    [Header("Door references")]
    public MainDoor mainDoor;

    [Header("Enviroment references")]
    public ParticleSystem fogSystem;
    public GameObject lightsContainer;
    public GameObject[] sceneLights;
    public GameObject[] nocturnalLights;
    public LightsEmergencyBehaviour[] emergencyLights;

    [Header("Ambient Sounds")]
    public AudioAmbience ambient;
    public SpatialSoundTrigger[] phoneBossAudios;
    public SpatialSoundTrigger[] lofiAudios;
    public SpatialSoundTrigger powerDown;
    public SpatialSoundTrigger mainDoorSfx;

    [Header("Piñatas references")]
    public EnemyController[] pinatas;
    #endregion

    #region Private variables
    private int score = 0;
    private int gameEvent = 0;
    #endregion

    void Awake() {
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public IEnumerator Start() {
        gameEvent = 0;
        score = 0;
        
        if(CamNota != null){
            CamNota.SetActive(true);
            Player.SetActive(false);
        }

        foreach(var elight in emergencyLights) elight.TurnOff();
        foreach(var nlight in nocturnalLights) nlight.SetActive(false);
    
        yield return new WaitForSeconds(1f);

        mainDoorSfx.Play();

        yield return new WaitForSeconds(2f);
        mainDoor.CloseDoors();

        yield return new WaitForSeconds(1f);
        foreach(var phoneAudio in phoneBossAudios) phoneAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(NotaStart)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                CamNota.SetActive(false);
                Player.SetActive(true);
            }
            
        }

        //25
        if(score >= 30 && gameEvent == 0){
            gameEvent++;

            powerDown.Play();
            foreach(Transform lightObject in lightsContainer.transform){
                var lightComponent = lightObject.GetComponent<LightsBehaviour>();
                lightComponent.TurnOff();
            }

            foreach(var nlight in nocturnalLights) nlight.SetActive(true);
            foreach(var light in sceneLights) light.SetActive(false);
            foreach(var elight in emergencyLights) elight.TurnOn();
        }

        if(score >= 40 && gameEvent == 1){
            gameEvent++;
            pinatas[0].CanMove(true);
            ambient.tension = 1;
        }

        if(score >= 50 && gameEvent == 2){
            gameEvent++;
            fogSystem.Play();
            ambient.tension = 1;
        }

        if(score >= 60 && gameEvent == 3){
            gameEvent++;
            pinatas[1].CanMove(true);
        }

        if(score >= 70 && gameEvent == 4){
            gameEvent++;
            pinatas[2].CanMove(true);
            ambient.tension = 2;
        }

        if(score >= 100 && gameEvent == 5){
            gameEvent++;

            foreach(Transform lightObject in lightsContainer.transform){
                var lightComponent = lightObject.GetComponent<LightsBehaviour>();
                lightComponent.TurnOn();
            }

            foreach(var nlight in nocturnalLights) nlight.SetActive(false);
            foreach(var light in sceneLights) light.SetActive(true);
            foreach(var elight in emergencyLights) elight.TurnOff();

            StopPinatas();
            ambient.tension = 0;
            mainDoor.OpenDoors();
            mainDoorSfx.Play();
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Puertas abiertas");
            mainDoor.OpenDoors();
            mainDoorSfx.Play();
        }
    }

    #region Public Methods
    public void AddScore() => score++;

    public void StopPinatas(){
        foreach(var pinata in pinatas) pinata.CanMove(false);
    }

    public void FinishGame(){
        SceneManager.LoadSceneAsync("Credits");
    }

    public void GameOver(){
        StopPinatas();
    }
    #endregion
}
