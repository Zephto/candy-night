using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBag : MonoBehaviour
{
    public Material[] materiasBag;

    public MeshRenderer CandyBagRenderer;

    // Start is called before the first frame update
    void Start()
    {
        CandyBagRenderer.material = materiasBag[Random.Range(0, materiasBag.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
