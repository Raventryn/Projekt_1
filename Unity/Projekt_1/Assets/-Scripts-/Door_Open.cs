using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    public float openRot=80, closeRot=0, speed=5;
    public bool opening;
    public int doorOpenTime=3;

    private float openRotActual;

    private void Start()
    {
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


    public IEnumerator DoorCloseAuto()
    {
        opening = true;
        yield return new WaitForSeconds(doorOpenTime);
        opening = false;
    }

    public void TriggerDoor()
    {
        StartCoroutine(DoorCloseAuto());
    }
}
