using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{

    public Transform zoneArm;
    public Rigidbody rb;
    public Collider coll;

    private void Start()
    {
        
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
