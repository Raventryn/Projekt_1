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

    private bool changedSteps;

    private int stepCase;

    private void Start()
    {
        DefaultPitch = PlayerAudio.pitch;
        HighPitch = DefaultPitch * 1.55f;
        stepCase = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && PlayerFPS.Grounded && !AudioIsPlaying)
        {
            AudioIsPlaying = true;
            SwitchPlayerSteps();
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("GroundGrass"))
        {
            stepCase = 1;
        }

        if (other.CompareTag("GroundWood"))
        {
            stepCase = 2;
        }
        if (other.CompareTag("GroundDirt"))
        {
            stepCase = 3;
        }

        if (other.CompareTag("GroundWoodReplace"))
        {
            stepCase = 4;
        }

        if (other.CompareTag("GroundGrassReplace"))
        {
            stepCase = 5;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GroundGrass"))
        {
            stepCase = 1;
            PlayerAudio.Stop();
            AudioIsPlaying = false;
        }

        if (other.CompareTag("GroundWood"))
        {
            stepCase = 2;
            PlayerAudio.Stop();
            AudioIsPlaying = false;
        }
        if (other.CompareTag("GroundDirt"))
        {
            stepCase = 3;
            PlayerAudio.Stop();
            AudioIsPlaying = false;
        }

        if (other.CompareTag("GroundWoodReplace"))
        {
            stepCase = 4;
            PlayerAudio.Stop();
            AudioIsPlaying = false;
        }

        if (other.CompareTag("GroundGrassReplace"))
        {
            stepCase = 5;
            PlayerAudio.Stop();
            AudioIsPlaying = false;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if ((PlayerAudio.clip != DefaultSteps) && !other.CompareTag("GroundWoodReplace"))
        {
            stepCase = 6;
            PlayerAudio.Stop();
            AudioIsPlaying = false;
        }
    }

    private void SwitchPlayerSteps()
    {

        switch (stepCase)
        {
            case 1:
                PlayerAudio.clip = GrassSteps;
                PlayerAudio.Play();
                break;
            case 2:
                PlayerAudio.clip = WoodSteps;
                PlayerAudio.Play();
                break;
            case 3:
                PlayerAudio.clip = DirtSteps;
                PlayerAudio.Play();
                break;
            case 4:
                PlayerAudio.clip = WoodSteps;
                PlayerAudio.Play();
                break;
            case 5:
                PlayerAudio.clip = GrassSteps;
                PlayerAudio.Play();
                break;
            case 6:
                PlayerAudio.clip = DefaultSteps;
                PlayerAudio.Play();
                break;
        }
    }
}
