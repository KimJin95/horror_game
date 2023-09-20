using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzle_UI : MonoBehaviour
{
    [Header("Lead------------------")]
    public GameObject Lead1;
    public GameObject Lead2;

    public bool openUI;

    public GameObject fireLead;

  

    void Start()
    {
        Lead1.SetActive(false);
        Lead2.SetActive(false);
        fireLead.SetActive(false);
    }


    void Update()
    {
       
    }

    public void OpenFireLead()
    {
        fireLead.SetActive(true);
        openUI = true;
    }


    public void ToggleUI(GameObject leadUI)
    {
        openUI= !openUI;
        leadUI.SetActive(openUI);
    }

    public void CloseUI()
    {
        openUI = false;
        CloseAllUI();
    }

    public void CloseAllUI()
    {
        Lead1.SetActive(false);
        Lead2.SetActive(false);

        fireLead.SetActive(false);
    }
}
