using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Pickup : MonoBehaviour
{
    public bool hasKey;
    public GameObject Key;
    public GameObject InteractionText;

    void Start()
    {
        hasKey = false;
        Key.SetActive(true);
        InteractionText.SetActive(false);
    }

 


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasKey)
        {
            hasKey = true;
            Key.SetActive(false);
            InteractionText.SetActive(false);
        }
        else if (!hasKey)
        {
            InteractionText.SetActive(true);
        }

    }

    private void OnTriggerExit()
    {
        InteractionText.SetActive(false);
    }


}
