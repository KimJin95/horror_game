using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    Keys keys;
    SoundManager soundManager;
    Bunker_Enter bunker;

    [Header("Keys-----------------------")]
    public GameObject Room2_Key;
    public GameObject Room3_Key;


    [Header("LockDoor------------------")]
    public GameObject Room2_Door;
    public bool room2_Open;
    public GameObject Room3_Door;
    public bool room3_Open;
    public GameObject Escape_Door;
    public bool escapeDoor_Open;

    [Header("unLockDoor------------------")]
    public GameObject Room1_Door;
    public GameObject Room4_Door;
    public GameObject BathRoom_Door;


    [Header("Anim------------------")]
    public Animator door2_Anim;
    public Animator door3_Anim;
    public Animator door1_Anim;
    public Animator door4_Anim;
    public Animator bathroom_Door_Anim;
    public Animator escapeDoor_Anim1;
    public Animator escapeDoor_Anim2;

    public GameObject slenderMan;

    void Start()
    {
        keys = FindObjectOfType<Keys>();
        soundManager = FindObjectOfType<SoundManager>();
        bunker = FindObjectOfType<Bunker_Enter>();
    }

    public void OpenRoom()
    {

        if (keys.hasRoom2Key)
        {
            if (keys.Room2_key == null && !room2_Open)
            {
                door2_Anim.SetTrigger("Open"); soundManager.Door2Audio.Play();

                //keys.hasRoom2Key = false;
                //room2_Open = false;
            }
        }
        else if (keys.hasRoom3Key)
        {
            if (keys.Room3_key == null && !room3_Open)
            {
                door3_Anim.SetTrigger("Open"); soundManager.Door3Audio.Play();

                bunker.BlackUI.SetActive(true);
                // keys.hasRoom3Key = false;
                //room3_Open = false;
            }
        }
        else if (keys.hasEscapeKey)
        {
            if (keys.escapeKey == null && !escapeDoor_Open)
            {
                escapeDoor_Anim1.SetTrigger("Open");
                escapeDoor_Anim2.SetTrigger("Open");
                soundManager.EscapeDoorOpen();

                // keys.hasEscapeKey = false;
                // escapeDoor_Open = false;
            }
        }
        else
        {
            soundManager.LockedDoor();
        }

    }


}
