using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public CanvasGroup Image;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame ()
    {
        StartCoroutine(FadeOut(2));
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public IEnumerator FadeOut(float duration)
    {
        AudioListener.volume = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        float t = 0f;
        while (t < duration)

        {
            AudioListener.volume -= 0.01f;
            t += Time.deltaTime;
            Image.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }

        AudioListener.volume = 0f;
        Image.alpha = 1f;
        SceneManager.LoadScene("Outside");
    }
}
