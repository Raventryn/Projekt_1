using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal_Trigger : MonoBehaviour
{

    public bool replacePage;

    public int replacedPageIndex = 0;

    public int newPageIndex;

    public int switchCase;

    private Journal_Pages JP;

    // Start is called before the first frame update
    void Start()
    {
        JP = GameObject.Find("-JOURNAL-").GetComponent<Journal_Pages>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AddPage();
    }

    private void AddPage()
    {
        if(!replacePage) 
        {
            JP.AddPage(switchCase);
        }

        else
        {
            JP.ReplacePage(replacedPageIndex, newPageIndex);
        }

    }

}
