using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform Cam;

    public float rayDistance;

    private Animator aniPuerta;

    public bool puertaActiv = true;

    public bool OpenDoor;

    private SpatialSoundTrigger doorSfx;

    void Awake() {
        aniPuerta   = this.GetComponent<Animator>();
        doorSfx     = this.GetComponent<SpatialSoundTrigger>();
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
                Debug.Log("Click in: " + this.gameObject);
                Debug.Log("hit door: "+ hit.transform.gameObject);

                if(this.gameObject == hit.transform.GetComponentInParent<Door>().gameObject){

                    if(puertaActiv == true && OpenDoor == true)
                    {
                        aniPuerta.SetBool("DoorOpen", false);
                        puertaActiv = false;
                        OpenDoor = false;
                        Invoke("DoorBool", 1f);
                        doorSfx.Play();
                    }

                    if(puertaActiv == false && OpenDoor == true)
                    {
                        aniPuerta.SetBool("DoorOpen", true);
                        puertaActiv = true;
                        OpenDoor = false;
                        Invoke("DoorBool", 1f);
                        doorSfx.Play();
                    }
                }

            }
        }

    }

    public void DoorBool()
    {
        OpenDoor = true;
    }
}
