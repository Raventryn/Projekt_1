using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Journal_Pages : MonoBehaviour
{
    public GameObject _Journal;

    public GameObject newEntryText;

    public GameObject[] Pages;

    public Button Page_Forward;

    public Button Page_Backward;

    private List<GameObject> Known_Pages = new List<GameObject>();

    private CanvasGroup TextCG;

    private int current_Page = 0;

    private bool journalActive = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

         TextCG = newEntryText.GetComponent<CanvasGroup>();

        _Journal.SetActive(false);
        Known_Pages.Add(Pages[0]);
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
            journalActive = true;
            Known_Pages[current_Page].SetActive(true);
            _Journal.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;       
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Escape) && journalActive)
        {
            journalActive = false;
            _Journal.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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

    public void AddPage(int journalEvent)
    {
        Debug.Log("Methode aufgerufen");

        switch(journalEvent)
        {
            case 1:
                Debug.Log("Page added");
                Known_Pages.Add(Pages[1]);
                StartCoroutine(EntryText());
                Debug.Log(Known_Pages.Count);
                break;
            case 2:
                Known_Pages.Add(Pages[2]);
                Known_Pages.Add(Pages[3]);
                StartCoroutine(EntryText());
                break;
        }
    

    }

    private void PreviousPage()
    {
        Known_Pages[current_Page].SetActive(false);
        current_Page--;
        Known_Pages[current_Page].SetActive(true);
    }

    private void NextPage()
    {
        Known_Pages[current_Page].SetActive(false);
        current_Page++;
        Known_Pages[current_Page].SetActive(true);
    }

    private IEnumerator EntryText()
    {
        Debug.Log("Coroutine gestartet");
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
