using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flower_Pickup : MonoBehaviour
{
    public GameObject Icon;

    private Fade_Scene FadeScene;

    private void Start()
    {
        FadeScene = GetComponent<Fade_Scene>();
    }

    private void OnTriggerStay(Collider other)
    {
        Icon.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            FadeScene.SceneChangeFade();
        }
   
      
    }

    private void OnTriggerExit(Collider other)
    {

            Icon.SetActive(false);
    }
}
