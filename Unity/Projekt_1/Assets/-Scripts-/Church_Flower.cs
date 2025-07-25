using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church_Flower : MonoBehaviour
{
    public GameObject Mirrors;
    public GameObject FlowersHealthy;
    public GameObject FlowerDried;
    // Start is called before the first frame update
    void Start()
    {
        Mirrors.SetActive(false);
        FlowerDried.SetActive(false);
        FlowersHealthy.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMirrors()
    {
        Mirrors.SetActive(true);
        FlowerDried.SetActive(true);
        FlowersHealthy.SetActive(false);
    }
}
