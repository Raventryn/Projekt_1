using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Journal_TriggerReplace : MonoBehaviour
{
    public int FadeDelay;

    public float FadeDuration;

    public GameObject Image;

    private End_Journal Journal;

    private bool JournalOpened = false;

    private bool JournalReplaced = false;

    private CanvasGroup CG;

    private void Start()
    {
        Journal = GameObject.Find("-JOURNAL-").GetComponent<End_Journal>();
        CG = Image.GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if(Journal.journalActive && !JournalOpened && JournalReplaced)
        {
            JournalOpened = true;
        }
        else if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.J)) && JournalOpened && JournalReplaced) 
        {
            StartCoroutine(Cutscene());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ReplaceJournal"))
        {
            Journal.ReplaceJournal();
            other.gameObject.SetActive(false);
            JournalReplaced = true;

            Debug.Log("Journal Replaced: " + JournalReplaced);
        }

        if (other.CompareTag("ForceJournal"))
        {
            Journal.OpenJournal();
            gameObject.GetComponent<CharacterController>().enabled = false;
        }

    }

    private IEnumerator Cutscene()
    {
        //Animation

        yield return new WaitForSeconds(FadeDelay);

        float t = 0f;
        while (t < FadeDuration)

        {

            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / FadeDuration);
            yield return null;

        }

        CG.alpha = 1f;
        //SceneManager.LoadScene("");
    }
}
