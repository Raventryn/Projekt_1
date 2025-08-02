using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInTrigger : MonoBehaviour
{
    public AudioSource Audio;

    private bool _isPlaying;

    private bool _inTrigger;

    // Start is called before the first frame update
    void Start()
    {
        Audio.Stop();
    }
    private void OnTriggerExit(Collider other)
    {
        _inTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        _inTrigger = true;     
    }

    private void Update()
    {
        if (!_isPlaying && _inTrigger)
        {
            Audio.Play();
            _isPlaying = true;
        }

        else if (!_inTrigger && _isPlaying)
        {
            Audio.Stop();
            _isPlaying = false;
        }
    }

}
