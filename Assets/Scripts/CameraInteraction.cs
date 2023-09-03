using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{

    public Transform Cam;

    public float rayDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Cam.position, Cam.forward * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Cam.position, Cam.forward, out hit, rayDistance, LayerMask.GetMask("Interactable")))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
        
    }
}
