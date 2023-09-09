using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

/// <summary>
/// Componente que se usa para controlar las interacciones con raycast
/// </summary>
public class CameraInteraction : MonoBehaviour {

    #region Public variables
    public Transform Cam;
    public float rayDistance;
    public bool ArmBox;
    public RaycastHit hit;
    #endregion
    
    #region Private variables
    //private CandyEstant candyEstant;
    private CharacterAudios characterAudios;
    private string candyEstantId;
    private Pickable pickable;
    #endregion
    
    void Awake() {
        characterAudios = this.GetComponentInParent<CharacterAudios>();
    }

    void Update(){
        Debug.DrawRay(Cam.position, Cam.forward * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0))
        {          
            if (Physics.Raycast(Cam.position, Cam.forward, out hit, rayDistance, LayerMask.GetMask("Interactable")))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<Interactable>().Interact();
                pickable = hit.collider.GetComponent<Pickable>();
                ArmBox = true;
            }

            if (Physics.Raycast(Cam.position, Cam.forward, out hit, rayDistance, LayerMask.GetMask("PositionCandy")))
            {       
                if(ArmBox)
                {
                    var estantParent = hit.transform.GetComponentInParent<CandyEstant>();
                    //if(estantParent.gameObject.GetInstanceID().ToString() == candyEstantId){
                        Debug.Log(hit.transform.name);
                        estantParent.SpawnCandy(hit.collider.transform);
                        pickable.CantidadDeDulces--;
                        hit.collider.enabled = false;
                        characterAudios.PlayPlace();
                    //}else{
                        Debug.Log("Es otro estanteeee");
                    //}

                }                  
            }
        }
    }

    #region Private Methods
    public void SetEstant(GameObject candyEstantRef ){//CandyEstant candyEstantRef){
        //candyEstant = candyEstantRef;
        candyEstantId = candyEstantRef.gameObject.GetInstanceID().ToString();
    }
    #endregion
}
