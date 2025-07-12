using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Scene_Change : MonoBehaviour
{
    public GameObject Open_Door;

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
            transform.Rotate(Vector3.up * -5 * Time.deltaTime, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Open_Door.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Open_Door.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Door_Opening = true;
            FadeScene.SceneChangeFade();
        }
    }
}
