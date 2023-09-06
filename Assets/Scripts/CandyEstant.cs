using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CandyEstant : MonoBehaviour
{
    public GameObject Candy;
    public GameObject PositionsContainer;
    private Transform[] PositionsCandy;

    // Start is called before the first frame update
    void Start()
    {
        PositionsCandy = new Transform[PositionsContainer.transform.childCount];
        for(int i = 0; i < PositionsContainer.transform.childCount; i++)
        {
            PositionsCandy[i] = PositionsContainer.transform.GetChild(i);
        }       
    }

    public void SpawnCandy(Transform transform)
    {
        Instantiate(Candy, transform);
        GameManager.Instance.AddScore();
    }
}
