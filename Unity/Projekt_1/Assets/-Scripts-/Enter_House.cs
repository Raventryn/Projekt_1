using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enter_House : MonoBehaviour
{
    public GameObject Key;
    public GameObject InteractionText;
    public GameObject MissingKeyText;
    
    private Key_Pickup Key_Pickup;   
    private Fade_Scene Fade_Scene;

    void Start()
    {
        Key_Pickup = Key.GetComponent<Key_Pickup>();
        InteractionText.SetActive(false);
        MissingKeyText.SetActive(false);
        
        Fade_Scene = GetComponent<Fade_Scene>();
        
    }

    private void OnTriggerStay()
    {
        if (Key_Pickup.hasKey && Input.GetKeyDown(KeyCode.E))
        {
            Fade_Scene.SceneChangeFade();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            MissingKeyText.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractionText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        InteractionText.SetActive(false);
        MissingKeyText.SetActive(false);
    }


}
