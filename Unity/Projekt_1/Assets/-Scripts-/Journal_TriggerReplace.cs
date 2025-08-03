using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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

    public AudioSource Audio;

    public AudioSource WindAudio;

    public AudioSource Grass1Audio;

    public AudioSource Grass2Audio;

    public AudioSource Grass3Audio;

    public AudioSource Cicada1Audio;

    public AudioSource Cicada2Audio;

    public AudioSource Cicada3Audio;

    public AudioSource WindmillAudio;

    private End_Journal Journal;

    private bool JournalOpened = false;

    private bool JournalReplaced = false;

    private CanvasGroup CG;

    private GameObject PCR;

    private bool triggeredCutscene;

    private void Start()
    {
        Journal = GameObject.Find("-JOURNAL-").GetComponent<End_Journal>();
        PCR = GameObject.Find("PlayerCameraRoot");
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
            StartCoroutine(FadeOutAudio(2));
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
        PCR.transform.localEulerAngles = new Vector3(0, PCR.transform.localEulerAngles.y, PCR.transform.localEulerAngles.z);
        Cursor.lockState = CursorLockMode.None;
        armAnimator.gameObject.GetComponent<MeshRenderer>().enabled = true;
        armAnimator.SetTrigger("JournalClosed");
        Audio.Play();

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
        triggeredCutscene = false;
        SceneManager.LoadScene("Credits");
    }

    private IEnumerator FadeOutAudio(float duration)
    {
        Debug.Log("Started Coroutine");
        float t = 0f;
        while (t < duration)

        {

            t += Time.deltaTime;
            WindAudio.volume -= 0.01f;
            Grass1Audio.volume -= 0.001f;
            Grass2Audio.volume -= 0.001f;
            Grass3Audio.volume -= 0.001f;
            Cicada1Audio.volume -= 0.001f;
            Cicada2Audio.volume -= 0.001f;
            Cicada3Audio.volume -= 0.001f;
            WindmillAudio.volume -= 0.001f;
            yield return null;
            Debug.Log(Audio.volume);

        }

        WindAudio.volume = 0f;
        Grass1Audio.volume = 0f;
        Grass2Audio.volume = 0f;
        Grass3Audio.volume = 0f;
        Cicada1Audio.volume = 0f;
        Cicada2Audio.volume = 0f;
        Cicada3Audio.volume = 0f;
        WindmillAudio.volume = 0f;

    }
}
