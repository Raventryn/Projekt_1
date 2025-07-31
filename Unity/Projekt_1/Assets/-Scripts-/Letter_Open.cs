using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter_Open : MonoBehaviour
{
    public GameObject letterUI;

    public bool letterOpen;

    public void ShowLetter()
    {
        letterUI.SetActive(true);
        letterOpen = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseLetter()
    {
        letterOpen = false;
        letterUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

}
