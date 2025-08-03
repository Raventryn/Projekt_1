using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPromptFade : MonoBehaviour
{
    public bool showOnStart = false;

    private CanvasGroup CG;

    private AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        CG = GetComponent<CanvasGroup>();
        Audio = GetComponent<AudioSource>();
        CG.alpha = 0f;
        if(showOnStart)
        {
            TriggerQuestPrompt(2);
        }
    }

    public void TriggerQuestPrompt(float delay)
    {
        
        StartCoroutine(Fade(delay));
    }

    private IEnumerator Fade(float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        CG.enabled = true;
        Audio.Play();

        float t = 0f;
        while (t < 1)

        {

            t += Time.deltaTime;
            CG.alpha = Mathf.Clamp01(t / 1);
            yield return null;

        }

        CG.alpha = 1f;

        yield return new WaitForSeconds(4);

        t = 0f;
        while (t < 1)

        {

            t += Time.deltaTime;
            CG.alpha = 1 - Mathf.Clamp01(t / 1);
            yield return null;

        }

        CG.alpha = 0f;
    }
}
