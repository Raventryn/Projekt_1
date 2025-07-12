using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway_Change : MonoBehaviour
{
    public GameObject First_Floor;
    public GameObject Bedroom;
    public GameObject Washroom;
    public GameObject Hallway_Normal;

    public bool Picked_Flower;

    public GameObject Hallways_Broken;

    // Start is called before the first frame update
    void Start()
    {
        First_Floor.SetActive(true);
        Bedroom.SetActive(true);
        Washroom.SetActive(true);
        Hallway_Normal.SetActive(true);

        Hallways_Broken.SetActive(false);

        Picked_Flower = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.E)) 
        {
            DisableRooms();
        }
    }

    private void DisableRooms()
    {
        First_Floor.SetActive(false);
        Bedroom.SetActive(false);
        Washroom.SetActive(false);
        Hallway_Normal.SetActive(false);

        Hallways_Broken.SetActive(true);
    }
}
