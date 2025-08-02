using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class AudioOnWalk_Collision : MonoBehaviour
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

    private bool _inTrigger;

    private void Start()
    {
        DefaultPitch = PlayerAudio.pitch;
        HighPitch = DefaultPitch * 1.55f;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && PlayerFPS.Grounded && !AudioIsPlaying)
        {
            PlayerAudio.Play();
            AudioIsPlaying = true;
        }
        else if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) || !PlayerFPS.Grounded)
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

    private void Raycast()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red,0.1f);
        //Physics.Raycast(transform.position, Vector3.down, 0.3f);
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.01f))
        {
            
            
            if(hit.collider.tag == "GroundGrass")
            {
                Debug.Log("HitGrass");
                PlayerAudio.clip = GrassSteps;
            }

            if(hit.collider.tag == "GroundWood")
            {
                Debug.Log("HitWood");
                PlayerAudio.clip = WoodSteps;
            }

            if(hit.collider.tag == "GroundDirt")
            {
                PlayerAudio.clip = DirtSteps;
            }
        }
    }      
        
}
