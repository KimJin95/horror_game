using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Hide : MonoBehaviour
{
    Camera_Ray camRay;

    [Header("Cabinet-----------")]
    public GameObject cabinet1;
    public GameObject cabinet2;
    public GameObject cabinet3;
    public GameObject cabinet4;
    public GameObject cabinet5;

    [Header("Cabunet_Hide_Pos---------")]
    public Transform cabinet1_hide_Pos;
    public Transform cabinet2_hide_Pos;
    public Transform cabinet3_hide_Pos;
    public Transform cabinet4_hide_Pos;
    public Transform cabinet5_hide_Pos;

    [Header("Cabunet_Aim---------")]
    public Animator cabinet1_anim;
    public Animator cabinet2_anim;
    public Animator cabinet3_anim;
    public Animator cabinet4_anim;
    public Animator cabinet5_anim;

    [Header("Bed---------------")]
    public GameObject bed1;
    public GameObject bed2;
    public GameObject bed3;
    public GameObject bed4;
    public GameObject bed5;


    [Header("Bed_Hide_Pos---------------")]
    public Transform bed1_hide_Pos;
    public Transform bed2_hide_Pos;
    public Transform bed3_hide_Pos;
    public Transform bed4_hide_Pos;
    public Transform bed5_hide_Pos;
 

    [Header("Bed_UnHide_Pos---------------")]
    public Transform bed1_unhide_Pos;
    public Transform bed2_unhide_Pos;
    public Transform bed3_unhide_Pos;
    public Transform bed4_unhide_Pos;
    public Transform bed5_unhide_Pos;


    SoundManager soundManager;
    Transform playerObj;

    public static bool isHide;

    void Start()
    {
        playerObj = FindObjectOfType<CharacterController>().transform;
        soundManager=FindObjectOfType<SoundManager>();
    }

    public void HideCabinet_1()
    {
        playerObj.transform.position = cabinet1_hide_Pos.position;
        isHide = true;
    }
    public void HideCabinet_2()
    {
        playerObj.transform.position = cabinet2_hide_Pos.position;
        isHide = true;
    }
    public void HideCabinet_3()
    {
        playerObj.transform.position = cabinet3_hide_Pos.position;
        isHide = true;
    }
    public void HideCabinet_4()
    {
        playerObj.transform.position = cabinet4_hide_Pos.position;
        isHide = true;
    }
    public void HideCabinet_5()
    {
        playerObj.transform.position = cabinet5_hide_Pos.position;
        isHide = true;
    }


    public void HideBed1()
    {
        playerObj.position = bed1_hide_Pos.position;
        isHide = true;
    }
    public void HideBed2()
    {
        playerObj.position = bed2_hide_Pos.position;
        isHide = true;
    }
    public void HideBed3()
    {
        playerObj.position = bed3_hide_Pos.position;
        isHide = true;
    }
    public void HideBed4()
    {
        playerObj.position = bed4_hide_Pos.position;
        isHide = true;
    }
    public void HideBed5()
    {
        playerObj.position = bed5_hide_Pos.position;
        isHide = true;
    }

    public void UnHideBed1()
    {
        playerObj.position = bed1_unhide_Pos.position;
        isHide = false;
        soundManager.isfearBreath = false;
    }
    public void UnHideBed2()
    {
        playerObj.position = bed2_unhide_Pos.position;
        isHide = false;
        soundManager.isfearBreath = false;
    }
    public void UnHideBed3()
    {
        playerObj.position = bed3_unhide_Pos.position;
        isHide = false;
        soundManager.isfearBreath = false;
    }
    public void UnHideBed4()
    {
        playerObj.position = bed4_unhide_Pos.position;
        isHide = false;
        soundManager.isfearBreath = false;
    }
    public void UnHideBed5()
    {
        playerObj.position = bed5_unhide_Pos.position;
        isHide = false; soundManager.isfearBreath = false;
    }
}
