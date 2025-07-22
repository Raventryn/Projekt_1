using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class Bloom_Theater : MonoBehaviour
{
    public Volume volume;
    public bool flowersSpawned;
    public float TargetBloom;
    public Light Light_1;
    public Light Light_2;
    public Light Light_3;
    public Light Light_4;
    public Light Light_5;
    public float LightTargetIntensity;


    private float DefaultBloomThreshold;
    private float DefaultLightIntensity;
    private float CurrentBloomThreshold;
    private float CurrentLightIntensity;

    private void Start()
    {
        DefaultBloomThreshold = 2;
        DefaultLightIntensity = Light_1.intensity;
        CurrentBloomThreshold = DefaultBloomThreshold;
        CurrentLightIntensity = DefaultLightIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (flowersSpawned == true)
        {
            if (volume.profile.TryGet(out Bloom bloom))
            {
                bloom.threshold.value = Mathf.MoveTowards(CurrentBloomThreshold, TargetBloom, 0.0000001f + Time.deltaTime);
                CurrentBloomThreshold = bloom.threshold.value;
                Light_1.intensity = Mathf.MoveTowards(CurrentLightIntensity, LightTargetIntensity, 0.00002f + Time.deltaTime);
                Light_2.intensity = Mathf.MoveTowards(CurrentLightIntensity, LightTargetIntensity, 0.00002f + Time.deltaTime);
                Light_3.intensity = Mathf.MoveTowards(CurrentLightIntensity, LightTargetIntensity, 0.00002f + Time.deltaTime);
                Light_4.intensity = Mathf.MoveTowards(CurrentLightIntensity, LightTargetIntensity, 0.00002f + Time.deltaTime);
                Light_5.intensity = Mathf.MoveTowards(CurrentLightIntensity, LightTargetIntensity, 0.00002f + Time.deltaTime);
                CurrentLightIntensity = Light_1.intensity;
            }
        }
    }
}
