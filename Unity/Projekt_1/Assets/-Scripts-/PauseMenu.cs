using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public CanvasGroup CG;

    public Button Resume;
    public Button Options;
    public Button Quit;

    private Canvas OptionsMenu;
    private Button Return;
    //private AudioSource Audio;

    private bool pauseActive = false;
    private bool optionsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Return = GameObject.Find("Return").GetComponent<Button>();
        OptionsMenu = GameObject.Find("Options_DDOL").GetComponent<Canvas>();
        //Audio = GetComponent<AudioSource>();

        Resume.onClick.AddListener(() => TogglePauseMenu()); ;
        Options.onClick.AddListener(() => ToggleOptions());
        Quit.onClick.AddListener(() => StartCoroutine(FadeScene(2)));
        Return.onClick.AddListener(() => ToggleOptions());

        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }


    private void TogglePauseMenu()
    {
        pauseActive = !pauseActive;
        if(pauseActive )
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if ( !pauseActive )
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            OptionsMenu.enabled = false;
            Time.timeScale = 1;
        }
    }

    private void ToggleOptions()
    {
        optionsActive = !optionsActive;
        if( optionsActive )
        {
            //Audio.Play();
            pauseMenu.SetActive(false);
            OptionsMenu.enabled = true;
        }
        else if( !optionsActive)
        {
            //Audio.Play();
            pauseMenu.SetActive(true);
            OptionsMenu.enabled = false;
        }
        
    }

    private IEnumerator FadeScene(float duration)
    {
        //Audio.Play();
        Time.timeScale = 1;
        float maxVolume = GameObject.Find("Options_DDOL").GetComponent<GameSettings>().volume;
        AudioListener.volume = maxVolume;
        float t = 0f;
        while (t < duration)

        {
            AudioListener.volume = Mathf.Clamp(AudioListener.volume -= 0.01f, 0, maxVolume);
            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / duration);
            yield return null;

        }
        AudioListener.volume = 0f;
        CG.alpha = 1f;
        Destroy(OptionsMenu.gameObject);
        SceneManager.LoadScene("Main_Menu");
    }
}
