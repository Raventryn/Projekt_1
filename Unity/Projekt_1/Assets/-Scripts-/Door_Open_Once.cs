using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_Open_Once : MonoBehaviour
{
    public float openRot=80, closeRot=0, speed=5;
    public bool opening;
    public int doorOpenTime=3;
    public GameObject Open_Icon;
    public GameObject Cannot_Open_Icon;

    private float openRotActual;
    private bool has_Opened;

    private void Start()
    {
        Open_Icon.SetActive(false);
        Cannot_Open_Icon.SetActive(false);
        opening = false;
        closeRot = transform.localEulerAngles.y;
        openRotActual = closeRot + openRot;

        has_Opened = false;
    }

    void Update()
    {
        Vector3 currentRot = transform.localEulerAngles;
        if (opening)
        {
            if (currentRot.y < openRotActual)
            {
                transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, openRotActual, currentRot.z), speed * Time.deltaTime);
            }
        }

        else
        {
            if (currentRot.y > closeRot)
            {
                transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, closeRot, currentRot.z), speed * 0.4f * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !has_Opened)
        {
            StartCoroutine (DoorCloseAuto());
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!opening && !has_Opened)
        {
            Open_Icon.SetActive(true);
        }

        else if(has_Opened) 
        { 
            Cannot_Open_Icon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Open_Icon.SetActive(false);
        Cannot_Open_Icon.SetActive(false);
    }

    IEnumerator DoorCloseAuto()
    {
        opening = true;
        yield return new WaitForSeconds(doorOpenTime);
        opening = false;
        has_Opened = true;
    }
}
