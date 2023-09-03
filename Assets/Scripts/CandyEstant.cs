using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyEstant : MonoBehaviour
{
    public GameObject Candy;
    public Transform[] PositionsCandy;

    public int CantidadDeDulces;

    public CameraInteraction cameraInteraction;

    // Start is called before the first frame update
    void Start()
    {
        PositionsCandy = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            PositionsCandy[i] = transform.GetChild(i);
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCandy(int number)
    {
        Instantiate(Candy , cameraInteraction.hit.collider.transform);
        cameraInteraction.hit.collider.enabled = false;
    }
}
