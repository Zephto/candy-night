using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CamNota;
    public GameObject Player;

    public bool NotaStart = true;

    // Start is called before the first frame update
    void Start()
    {
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
    }
}
