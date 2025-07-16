using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church_Flower : MonoBehaviour
{
    public GameObject Mirrors;
    public GameObject FlowersPlaceholder;
    // Start is called before the first frame update
    void Start()
    {
        Mirrors.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMirrors()
    {
        Mirrors.SetActive(true);
    }
}
