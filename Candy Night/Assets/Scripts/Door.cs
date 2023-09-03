using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform Cam;

    public float rayDistance;

    public Animator aniPuerta;

    public bool puertaActiv = true;

    public bool OpenDoor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Cam.position, Cam.forward * rayDistance, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Cam.position, Cam.forward, out hit, rayDistance, LayerMask.GetMask("Door")))
            {
                Debug.Log("Click");

                if(puertaActiv == true && OpenDoor == true)
                {
                    aniPuerta.Play("DoorClose");
                    puertaActiv = false;
                    OpenDoor = false;
                    Invoke("DoorBool", 1f);
                }

                if(puertaActiv == false && OpenDoor == true)
                {
                    aniPuerta.Play("DoorOpen");
                    puertaActiv = true;
                    OpenDoor = false;
                    Invoke("DoorBool", 1f);
                }
            }
        }

    }

    public void DoorBool()
    {
        OpenDoor = true;
    }
}
