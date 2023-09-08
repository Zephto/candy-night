using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    [Header("Enviroment references")]
    public ParticleSystem fogSystem;
    public GameObject lightsContainer;
    public GameObject[] sceneLights;
    public GameObject[] nocturnalLights;
    public LightsEmergencyBehaviour[] emergencyLights;

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

    void Start() {
        gameEvent = 0;
        score = 0;
        
        if(CamNota != null){
            CamNota.SetActive(true);
            Player.SetActive(false);
        }

        foreach(var elight in emergencyLights) elight.TurnOff();
        foreach(var nlight in nocturnalLights) nlight.SetActive(false);
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
        if(score >= 10 && gameEvent == 0){
            gameEvent++;

            foreach(Transform lightObject in lightsContainer.transform){
                var lightComponent = lightObject.GetComponent<LightsBehaviour>();
                lightComponent.TurnOff();
            }

            foreach(var nlight in nocturnalLights) nlight.SetActive(true);
            foreach(var light in sceneLights) light.SetActive(false);
            foreach(var elight in emergencyLights) elight.TurnOn();
        }
        if(score >= 15 && gameEvent == 1){
            gameEvent++;
            pinatas[0].CanMove(true);
        }
        if(score >= 20 && gameEvent == 2){
            gameEvent++;
            pinatas[1].CanMove(true);
            fogSystem.Play();
        }
        if(score >= 25 && gameEvent == 3){
            gameEvent++;
            pinatas[2].CanMove(true);
        }
    }

    #region Public Methods
    public void AddScore() => score++;
    #endregion
}
