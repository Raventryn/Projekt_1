using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {

        mainCamera = Camera.main;

    }

    void LateUpdate()
    {
        Vector3 lookDirection = mainCamera.transform.position - transform.position;
        lookDirection.y = 0;

        if (lookDirection != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(lookDirection);
            transform.rotation = rot * Quaternion.Euler(90, 0, 0);
            //Debug.Log("aaa");
        }

    }
}