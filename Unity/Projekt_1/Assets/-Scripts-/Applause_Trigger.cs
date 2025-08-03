using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Applause_Trigger : MonoBehaviour
{
    public AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Audio.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(FadeInAudio(1));
        //Audio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FadeOutAudio(1));
        //Audio.Stop();
    }



    private IEnumerator FadeOutAudio(float duration)
    {
        Debug.Log("Started Coroutine");
        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            Audio.volume -= 0.01f;
            yield return null;
            Debug.Log(Audio.volume);

        }

        Audio.volume = 0f;
        Audio.Stop();
    }

    private IEnumerator FadeInAudio(float duration)
    {
        Audio.Play();
        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            Audio.volume += 0.01f;
            yield return null;

        }

        Audio.volume = 1f;
    }
}