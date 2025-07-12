using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_In : MonoBehaviour
{
    public float Fade_Duration = 1;
    public GameObject Image;

    private CanvasGroup CanvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        CanvasGroup = Image.GetComponent<CanvasGroup>();
        CanvasGroup.alpha = 1.0f;
        StartCoroutine(FadeIn(Fade_Duration));
    }


    public IEnumerator FadeIn(float duration)
    {
        CanvasGroup.alpha = 1.0f;

        float t = 1.3f;
        while (t >= 0)
          
        {

            t -= Time.deltaTime;
            CanvasGroup.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        CanvasGroup.alpha = 0f;
    }
}
