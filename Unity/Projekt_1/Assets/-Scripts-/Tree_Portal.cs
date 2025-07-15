using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Portal : MonoBehaviour
{
    public GameObject Checkpoint;
    public GameObject Player;
    public float Y_Coordinate;

    private CharacterController PC;
    private bool hasReachedEnd;
    private Fade_In Fade;
    private Fade_Scene FadeScene;

    private void Start()
    {
        PC = Player.GetComponent<CharacterController>();
        Fade = GetComponent<Fade_In>();
        hasReachedEnd = false;
        FadeScene = GetComponent<Fade_Scene>();
    }

    private void Update()
    {
        if (Player.transform.position.y < Y_Coordinate && hasReachedEnd)
        {
            FadeScene.SceneChangeFade();
        }

        else if (Player.transform.position.y < Y_Coordinate && !hasReachedEnd)
        {
            PC.enabled = false;
            Player.transform.position = Checkpoint.transform.position;
            Fade.StartCoroutine(Fade.FadeIn(1));
            PC.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hasReachedEnd = true;
    }
}
