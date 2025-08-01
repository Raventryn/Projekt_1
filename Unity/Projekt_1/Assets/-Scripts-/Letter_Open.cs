using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter_Open : MonoBehaviour
{
    public GameObject letterUI;

    public bool letterOpen;

    public AudioClip letterPickup;

    public AudioClip letterDrop;

    private AudioSource Audio;

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void ShowLetter()
    {
        Audio.clip = letterPickup;
        Audio.Play();
        letterUI.SetActive(true);
        letterOpen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseLetter()
    {
        Audio.clip = letterDrop;
        Audio.Play();
        letterOpen = false;
        letterUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
