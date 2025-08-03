using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public CanvasGroup CG;

    public Button Play;
    public Button Options;
    public Button Quit;
    public Button Return;

    public GameObject MainMenu;
    public Canvas OptionsMenu;

    //private AudioSource Audio;

    private bool OptionsActive;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Pause_Menu"));
        //Audio = GetComponent<AudioSource>();

        Play.onClick.AddListener(() => LoadGame());
        Options.onClick.AddListener(() => ToggleOptions());
        Return.onClick.AddListener(() => ToggleOptions());
        Quit.onClick.AddListener(() => QuitGame());

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadGame()
    {
        //Audio.Play();
        StartCoroutine(FadeScene(1));
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void ToggleOptions()
    {

        //Audio.Play();
        OptionsActive = !OptionsActive;

        if (OptionsActive)
        {
            MainMenu.SetActive(false);
            OptionsMenu.enabled = true;
        }
        else
        {
            MainMenu.SetActive(true);
            OptionsMenu.enabled = false;
        }
    }

    private void QuitGame()
    {
        //Audio.Play();
        StartCoroutine(FadeQuit(1));
    }

    private IEnumerator FadeScene(float duration)
    {
        float maxVolume = GameObject.Find("Options_DDOL").GetComponent<GameSettings>().volume;
        AudioListener.volume = maxVolume;
        float t = 0f;
        while (t < duration)

        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume -= 0.005f, 0, maxVolume);
            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }
        AudioListener.volume = 0f;
        CG.alpha = 1f;
        SceneManager.LoadScene("Outside");
    }

    private IEnumerator FadeQuit(float duration)
    {
        float maxVolume = GameObject.Find("Options_DDOL").GetComponent<GameSettings>().volume;
        AudioListener.volume = maxVolume;
        float t = 0f;
        while (t < duration)

        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume -= 0.005f, 0, maxVolume);
            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }
        AudioListener.volume = 0f;
        CG.alpha = 1f;
        Application.Quit();
    }
}
