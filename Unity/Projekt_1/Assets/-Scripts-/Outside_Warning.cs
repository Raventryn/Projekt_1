using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outside_Warning : MonoBehaviour
{
    public GameObject Warning_Text;

    // Start is called before the first frame update
    void Start()
    {
        Warning_Text.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        Warning_Text.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        Warning_Text.SetActive(false);
    }
}
