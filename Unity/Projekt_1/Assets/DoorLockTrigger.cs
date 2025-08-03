using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockTrigger : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
        Door.GetComponent<Door_Open_Once>().has_Opened = true;
    }
}
