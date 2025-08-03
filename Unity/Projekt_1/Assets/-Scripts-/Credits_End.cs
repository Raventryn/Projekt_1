using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits_End : MonoBehaviour
{
    public AnimationClip credits;
    private Fade_Scene fadeScene;

    // Start is called before the first frame update
    void Start()
    {
        fadeScene= GetComponent<Fade_Scene>();
        StartCoroutine(waitForCredits());
    }

    private IEnumerator waitForCredits()
    {
        yield return new WaitForSeconds(credits.length + 2);
        fadeScene.SceneChangeFade();
        Destroy(GameObject.Find("Options_DDOL"));
    }
}
