using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Scene_Change_Outside : MonoBehaviour
{
    public AudioClip doorLocked;
    public AudioClip doorOpen;

    private Fade_Scene FadeScene;
    private bool Door_Opening;
    // Start is called before the first frame update
    void Start()
    {
        FadeScene = GetComponent<Fade_Scene>();
        Door_Opening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Door_Opening)
        {
            transform.Rotate(Vector3.forward * -5 * Time.deltaTime, Space.Self);
        }
    }

    public void SceneChange()
    {
        Door_Opening = true;
        FadeScene.SceneChangeFade();
    }
}
