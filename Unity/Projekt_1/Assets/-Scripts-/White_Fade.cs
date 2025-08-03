using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class White_Fade : MonoBehaviour
{
    public float FadeDelay = 2;
    public float FadeDuration = 2f;
    public GameObject BlackImage;
    public AudioClip Special;
    public AudioSource SpecialSource;
    public AudioSource Drone_2;
    public AudioSource Applause;

    private CanvasGroup Image;

    // Start is called before the first frame update
    private void Start()
    {
        Image = BlackImage.GetComponent<CanvasGroup>();
        Image.alpha = 0f;
    }

    private IEnumerator FadeOut(float duration)
    {
        yield return new WaitForSeconds(FadeDelay);
        TriggerSound();
        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            Image.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        Image.alpha = 1f;
        yield return new WaitForSeconds(Special.length-3);
        SceneManager.LoadScene("Outside_End");
    }

    public void StartFade()
    {
        StartCoroutine(FadeOut(FadeDuration));
    }

    public void TriggerSound ()
    {
        Applause.Stop();
        StartCoroutine(CrossfadeSounds(1));
    }

    private IEnumerator CrossfadeSounds(float duration)
    {
        float spVolume = SpecialSource.volume;
        float droVolume = Drone_2.volume;

        SpecialSource.volume = 0f;
        SpecialSource.Play();

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            SpecialSource.volume += Mathf.Clamp(0.01f, 0, spVolume);
            Drone_2.volume -= Mathf.Clamp(0.001f, 0, droVolume);
            yield return null;
        }

        Drone_2.Stop();
    }
}
