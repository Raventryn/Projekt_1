using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End_Journal: MonoBehaviour
{
    public GameObject _Journal;

    public GameObject newEntryText;

    public GameObject RepeatingPage_1;

    public GameObject RepeatingPage_2;

    public GameObject RepeatingPage_3;

    public GameObject[] Pages;

    public GameObject[] ReplacedPages;

    public Button Page_Forward;

    public Button Page_Backward;

    public bool journalActive = false;

    public AudioClip journalOpen;

    public AudioClip journalClose;

    public AudioClip pageBack;

    public AudioClip pageForward;

    public AudioClip newEntry;

    private AudioSource Audio;

    private List<GameObject> Known_Pages = new List<GameObject>();

    private CanvasGroup TextCG;

    private int current_Page = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        TextCG = newEntryText.GetComponent<CanvasGroup>();
        Audio = GetComponent<AudioSource>();

        _Journal.SetActive(false);
        Known_Pages.Add(Pages[0]);
        Known_Pages.Add(Pages[1]);
        Known_Pages.Add(Pages[2]);
        Debug.Log(Pages.Length);
        Debug.Log(Known_Pages.Count);

        Page_Forward.onClick.AddListener(() => NextPage());
        Page_Backward.onClick.AddListener(() => PreviousPage());

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J) && !journalActive)
        {            
            OpenJournal();
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Escape) && journalActive)
        {
            CloseJournal();
        }

        if (current_Page == 0)
        {
            Page_Backward.gameObject.SetActive(false);
            if (Known_Pages.Count == 1)
            {
                Page_Forward.gameObject.SetActive(false);
            }
            else
            {
                Page_Forward.gameObject.SetActive(true);
            }

        }
        else if (current_Page == Known_Pages.Count - 1)
        {
            Page_Forward.gameObject.SetActive(false);
            Page_Backward.gameObject.SetActive(true);
        }
        else
        {
            Page_Forward.gameObject.SetActive(true);
            Page_Backward.gameObject.SetActive(true);
        }
    }

    public void OpenJournal()
    {
        journalActive = true;
        Known_Pages[current_Page].SetActive(true);
        _Journal.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Audio.clip = journalOpen;
        Audio.Play();
    }

    public void CloseJournal()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Known_Pages[current_Page].SetActive(false);
        journalActive = false;
        _Journal.SetActive(false);
        Audio.clip = journalClose;
        Audio.Play();
    }


    public void ReplaceJournal()
    {
        Debug.Log("Called ReplaceJournal");
        StartCoroutine(EntryText());
        for ( int i = 0; i < Known_Pages.Count; i++)
        {
            Known_Pages[i] = ReplacedPages[i];
            Debug.Log("Replaced Page");
        }

        AddRepeatingPage();
    }

    public void AddRepeatingPage()
    {
        Known_Pages.Add(RepeatingPage_1);
        Known_Pages.Add(RepeatingPage_2);
        Known_Pages.Add(RepeatingPage_3);
    }

    private void PreviousPage()
    {
        Known_Pages[current_Page].SetActive(false);
        current_Page--;
        Known_Pages[current_Page].SetActive(true);
        Debug.Log(current_Page);
        Audio.clip = pageBack;
        Audio.Play();
    }

    private void NextPage()
    {
        Known_Pages[current_Page].SetActive(false);
        current_Page++;
        Known_Pages[current_Page].SetActive(true);
        Debug.Log(current_Page);
        Audio.clip = pageForward;
        Audio.Play();
    }

    private IEnumerator EntryText()
    {
        Debug.Log("Coroutine gestartet");
        Audio.clip = newEntry;
        Audio.Play();
        TextCG.alpha = 0f;

        float t = 1.3f;
        while (t >= 0)

        {

            t -= Time.deltaTime;
            TextCG.alpha = 1 - Mathf.Clamp01(t / 1);
            yield return null;

        }

        TextCG.alpha = 1f;


        yield return new WaitForSeconds(2);


        TextCG.alpha = 1.0f;

        t = 1.3f;
        while (t >= 0)

        {

            t -= Time.deltaTime;
            TextCG.alpha = Mathf.Clamp01(t / 1);
            yield return null;

        }

        TextCG.alpha = 0f;

        Debug.Log("Coroutine beendet");
        
    }
}
