using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Slider volumeSlider;

    public float volume;


    private void Awake()
    {
        volume = volumeSlider.value;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(); });
 
    }

    private void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        volume = volumeSlider.value;
    }
}
