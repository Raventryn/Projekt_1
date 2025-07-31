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

    public Animator armAnimator;

    public AnimationClip armAnimation;

    private End_Journal Journal;

    private bool JournalOpened = false;

    private bool JournalReplaced = false;

    private CanvasGroup CG;

    private void Start()
    {
        Journal = GameObject.Find("-JOURNAL-").GetComponent<End_Journal>();
        CG = Image.GetComponent<CanvasGroup>();
        armAnimator.gameObject.GetComponent<MeshRenderer>().enabled = false;
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
        GameObject.Find("PlayerCapsule").GetComponent<CharacterController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        armAnimator.gameObject.GetComponent<MeshRenderer>().enabled = true;
        armAnimator.SetTrigger("JournalClosed");

        yield return new WaitForSeconds(armAnimation.length + 2);

        armAnimator.gameObject.GetComponent<MeshRenderer>().enabled = false;
        float t = 0f;
        while (t < FadeDuration)

        {

            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / FadeDuration);
            yield return null;

        }

        CG.alpha = 1f;
        SceneManager.LoadScene("Credits");
    }
}
