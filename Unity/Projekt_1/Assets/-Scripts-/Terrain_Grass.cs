using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain_Grass : MonoBehaviour
{
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        terrain.terrainData.wavingGrassTint = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
