using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class RayCast : MonoBehaviour
{
    public float RayLength;
    public LayerMask layerMask;
    public GameObject Hand_Icon;
    public GameObject Open_Door_Icon;
    public GameObject Closed_Door_Icon;
    public bool flowersSpawned;

    private Camera MainCamera;
    private bool hasKey;
    private int flowersPlaced;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        Hand_Icon.SetActive(false);
        Open_Door_Icon.SetActive(false);
        Closed_Door_Icon.SetActive(false) ;
        hasKey = false;
        flowersPlaced = 0;
        flowersSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    private void Raycast()
    {
        Ray ray = MainCamera.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, RayLength, layerMask))
        {
            if (hit.collider.tag == "Key")
            {
                Hand_Icon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.enabled = false;
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    hasKey = true;
                }
            }
            
            if(hit.collider.tag == "LockedDoor")
            {
                Door_Scene_Change_Outside DSC = hit.collider.gameObject.GetComponent<Door_Scene_Change_Outside>();
                AudioSource Audio = hit.collider.gameObject.GetComponent<AudioSource>();

                if (Input.GetKeyDown(KeyCode.E) && hasKey)
                {
                    Audio.clip = DSC.doorOpen;
                    Audio.Play();
                    DSC.SceneChange();
                }
                else if (hasKey)
                {
                    Open_Door_Icon.SetActive(true);
                }
                else if (!hasKey && Input.GetKeyDown(KeyCode.E)) 
                {
                    GameObject.Find("QwestPrompt_2").GetComponent<QuestPromptFade>().TriggerQuestPrompt(0);
                    Audio.clip = DSC.doorLocked;
                    Audio.Play();
                }
                else if (!hasKey)
                {
                    Closed_Door_Icon.SetActive(true);
                }
            }

            if (hit.collider.tag == "Letter")
            {
                Hand_Icon.SetActive(true);
                Letter_Open LO = hit.collider.gameObject.GetComponent<Letter_Open>();

                if (Input.GetKeyDown(KeyCode.E) && !LO.letterOpen)
                {
                    LO.ShowLetter();
                }

                else if (LO.letterOpen && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E)))
                {
                    LO.CloseLetter();
                }
            }

            if (hit.collider.tag == "FlowerHouse")
            {
                Hand_Icon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Hallway_Change HC= hit.collider.gameObject.GetComponent<Hallway_Change>();
                    Journal_Pages JP = GameObject.Find("-JOURNAL-").GetComponent<Journal_Pages>();
                    JP.ReplacePage(2, 3);
                    HC.DisableRooms();
                    hit.collider.enabled = false;
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Creak_Audio").GetComponent<AudioSource>().Play();
                    GameObject.Find("Musicbox (1)").GetComponent<AudioSource>().enabled = false;
                }
            }

            if(hit.collider.tag == "HallwayPrompt")
            {
                GameObject.Find("QwestPrompt_2").GetComponent<QuestPromptFade>().TriggerQuestPrompt(1);
                hit.collider.enabled = false;
            }

            if(hit.collider.tag == "SceneChangeDoor")
            {
                Open_Door_Icon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Door_Scene_Change DSC = hit.collider.gameObject.GetComponent<Door_Scene_Change>();
                    DSC.SceneChange();
                }
            }

            if(hit.collider.tag == "Door")
            {
                Open_Door_Icon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    Door_Open DO = hit.collider.gameObject.GetComponent<Door_Open>();
                    DO.TriggerDoor();
                    hit.collider.gameObject.GetComponent <AudioSource>().Play();
                }
            }

            if (hit.collider.tag == "DoorOpenOnce")
            {
                Door_Open_Once DOO = hit.collider.gameObject.GetComponent<Door_Open_Once>();
                AudioSource Audio = hit.collider.gameObject.GetComponent<AudioSource>();
                bool hasOpened = DOO.has_Opened;
                if (Input.GetKeyDown(KeyCode.E) && !hasOpened)
                {                  
                    DOO.TriggerDoor();
                    Audio.clip = DOO.doorOpen;
                    Audio.Play();
                }
                else if (!hasOpened)
                {
                    Open_Door_Icon.SetActive(true);
                }
                else if (hasOpened && Input.GetKeyDown(KeyCode.E))
                {
                    Closed_Door_Icon.SetActive(false);
                    Audio.clip = DOO.doorLocked;
                    Audio.Play();
                }

                else if (hasOpened)
                {
                    Closed_Door_Icon.SetActive(false);
                }
            }

            if(hit.collider.tag == "FlowerTree")
            {
                Hand_Icon.SetActive(true);
                Fade_Scene FS = hit.collider.gameObject.GetComponent<Fade_Scene>();              
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Journal_Pages JP = GameObject.Find("-JOURNAL-").GetComponent<Journal_Pages>();

                    FS.SceneChangeFade();
                    hit.collider.enabled = false;
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
            }

            if(hit.collider.tag == "FlowerChurch")
            {
                Hand_Icon.SetActive(true);
                Church_Flower CF = hit.collider.gameObject.GetComponent<Church_Flower>();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    CF.SpawnMirrors();
                    hit.collider.enabled = false;
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    GameObject.Find("Portrait.Mary").GetComponent<AudioSource>().Play();
                    GameObject.Find("Blood_2").GetComponent<AudioSource>().Play();
                }
            }

            if(hit.collider.tag == "SceneChange")
            {
                Open_Door_Icon.SetActive(true);
                Fade_Scene FS = hit.collider.gameObject.GetComponent<Fade_Scene>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    FS.SceneChangeFade();
                    hit.collider.enabled = false;
                }
            }

            if (hit.collider.tag == "TheaterPrompt")
            {
                GameObject.Find("QwestPrompt_2").GetComponent<QuestPromptFade>().TriggerQuestPrompt(1);
            }

            if (hit.collider.tag == "FlowerTheater")
            {
                Hand_Icon.SetActive(true);
                MeshRenderer MR = hit.collider .gameObject.GetComponent<MeshRenderer>();
                White_Fade QA = hit.collider.gameObject.GetComponent<White_Fade>();
                Bloom_Theater BT = GameObject.Find("Global Volume").GetComponent<Bloom_Theater>();
                Collider FC = hit.collider;
                GameObject Journal = GameObject.Find("-JOURNAL-");
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    MR.enabled = true;
                    flowersPlaced++;
                    FC.enabled = false;
                    if (flowersPlaced == 3)
                    {
                        BT.flowersSpawned = true;
                        Destroy(Journal);
                        QA.StartFade();
                    }
                    Debug.Log("Placed Flower" + flowersPlaced);
                }
                
            }
        }
        else
        {
            Hand_Icon.SetActive(false);
            Open_Door_Icon.SetActive(false);
            Closed_Door_Icon.SetActive(false);
        }

            Debug.DrawRay(transform.position, Vector3.forward);
    }
}
