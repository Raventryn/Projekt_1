using UnityEngine;

public class AmbientLightController : MonoBehaviour
{
    public float Percentage;
    public float Intensity;

    private bool inTrigger = false;
    private Vector4 DefaultColor;
    private Vector4 CurrentColor;


    void Start()
    {
        DefaultColor = RenderSettings.ambientSkyColor;
        CurrentColor = DefaultColor;

    }

    void Update()
    {
        if (inTrigger && CurrentColor.magnitude > DefaultColor.magnitude * Intensity)
        {
            CurrentColor *= (1 - (Percentage * Time.deltaTime));
            RenderSettings.ambientSkyColor = CurrentColor;
        }

        else if (!inTrigger && CurrentColor.magnitude < DefaultColor.magnitude)
        {
            CurrentColor *= (1 + (Percentage * Time.deltaTime));
            RenderSettings.ambientSkyColor = CurrentColor;
        }
       
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}