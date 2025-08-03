using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade_Scene : MonoBehaviour
{
    public string Scene_Name;
    public float FadeDuration = 2f;

    public GameObject BlackImage;
    private CanvasGroup Image;

    // Start is called before the first frame update
    void Start()
    {
        BlackImage = GameObject.Find("BlackImage");
        Image = BlackImage.GetComponent<CanvasGroup>();
        Image.alpha = 0f;
    }

    public void SceneChangeFade()
    {
        StartCoroutine(FadeOut(FadeDuration));
    }

    public IEnumerator FadeOut(float duration)
    {


        float t = 0f;
        while (t < duration)

        {
            t += Time.deltaTime;
            Image.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        Image.alpha = 1f;
        SceneManager.LoadScene(Scene_Name);
    }
}
