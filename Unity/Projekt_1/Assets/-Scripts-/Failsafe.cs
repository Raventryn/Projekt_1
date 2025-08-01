using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failsafe : MonoBehaviour
{
    public GameObject Checkpoint;

    public float Y_Coordinate;

    private CharacterController PC;

    private Fade_In Fade;

    private void Start()
    {
        PC = GetComponent<CharacterController>();
        Fade = GameObject.Find("Player").GetComponent<Fade_In>();
    }

    private void Update()
    {
        if(transform.position.y < Y_Coordinate)
        {
            PC.enabled = false;
            transform.position = Checkpoint.transform.position;
            Fade.StartCoroutine(Fade.FadeIn(1));
            PC.enabled = true;
        }
    }
}
