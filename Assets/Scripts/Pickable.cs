using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{

    public Transform zoneArm;
    public Rigidbody rb;
    public Collider coll;

    public CandyEstant candyEstant;
    public CameraInteraction cameraInteraction;

    public int CantidadDeDulces;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(CantidadDeDulces == 0)
        {
            cameraInteraction.ArmBox = false;
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        base.Interact();

        transform.SetParent(zoneArm);
        transform.position = new Vector3(0,0,0);
        transform.rotation = new Quaternion(0,0,0,0);
        transform.position = zoneArm.position;
        
        rb.isKinematic = true; coll.enabled = false; rb.useGravity = false;

        

    }

}
