using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnWalk : MonoBehaviour
{
    public AudioSource PlayerAudio;

    public FirstPersonController PlayerFPS;

    public AudioClip DefaultSteps;

    public AudioClip WoodSteps;

    public AudioClip DirtSteps;

    public AudioClip GrassSteps;

    private bool AudioIsPlaying;

    private float DefaultPitch;

    private float HighPitch;

    private void Start()
    {
        DefaultPitch = PlayerAudio.pitch;
        HighPitch = DefaultPitch * 1.55f;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && PlayerFPS.Grounded && !AudioIsPlaying)
        {
            AudioIsPlaying = true;
            PlayerAudio.Play();
            Debug.Log("Audio Plays");
        }
        else if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) || !PlayerFPS.Grounded)
        {
            AudioIsPlaying = false;
            PlayerAudio.Stop();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            PlayerAudio.pitch = HighPitch;
        }
        else
        {
            PlayerAudio.pitch = DefaultPitch;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundGrass"))
        {
            PlayerAudio.clip = GrassSteps;
            PlayerAudio.Play();
        }

        if (other.CompareTag("GroundWood"))
        {
            PlayerAudio.clip = WoodSteps;
            PlayerAudio.Play();
        }
        if (other.CompareTag("GroundDirt"))
        {
            PlayerAudio.clip = DirtSteps;
            PlayerAudio.Play();
        }

        if (other.CompareTag("GroundWoodReplace"))
        {
            PlayerAudio.clip = WoodSteps;
            PlayerAudio.Play();
        }

        if (other.CompareTag("GroundGrassReplace"))
        {
            PlayerAudio.clip = GrassSteps;
            PlayerAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((PlayerAudio.clip != DefaultSteps) && !other.CompareTag("GroundWoodReplace"))
        {
            PlayerAudio.clip = DefaultSteps;
            PlayerAudio.Play();
        }
    }
}
