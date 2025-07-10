using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    public float openRot=80, closeRot=0, speed=5;
    public bool opening;
    public int doorOpenTime=3;
    public GameObject InteractionText;

    private float openRotActual;

    private void Start()
    {
        InteractionText.SetActive(false);
        opening = false;
        closeRot = transform.localEulerAngles.y;
        openRotActual = closeRot + openRot;
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
                transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, closeRot, currentRot.z), speed * 0.1f * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine (DoorCloseAuto());
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!opening)
        {
            InteractionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractionText.SetActive(false);
    }

    IEnumerator DoorCloseAuto()
    {
        opening = true;
        yield return new WaitForSeconds(doorOpenTime);
        opening = false;
    }
}
