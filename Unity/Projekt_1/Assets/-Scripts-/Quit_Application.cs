using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Application : MonoBehaviour
{
    public float FadeDelay = 2;
    public float FadeDuration = 2f;
    public GameObject BlackImage;

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
        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            Image.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        Image.alpha = 1f;
        Application.Quit();
    }

    public void StartFade()
    {
        StartCoroutine(FadeOut(FadeDuration));
    }
}
