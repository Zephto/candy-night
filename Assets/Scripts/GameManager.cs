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
    
    [Header("Piñatas references")]
    public EnemyController firstPinata;
    #endregion

    #region Private variables
    private int score = 0;
    #endregion

    void Awake() {
        if(Instance == null){
            Instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    void Start() {
        score = 0;
        
        CamNota.SetActive(true);
        Player.SetActive(false);
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

        if(score >= 5){
            firstPinata.CanMove(true);
        }
    }

    #region Public Methods
    public void AddScore() => score++;
    #endregion
}
