using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting.Antlr3.Runtime;

public class Camera_Ray : MonoBehaviour
{
    string excludedTag = "Untagged";
    public float raycastDistance = 10f;

    Puzzle_UI puzzle_UI;
    UIManager uimanager;
    Keys keys;
    Door_Open doorOpen;
    Bunker_Enter bunker_Enter;
    SoundManager soundManager;
    Hide hide_Scripts;
    TurnOn turnon;
    BatteryCharge battery;

    [Header("UI---------------------------------")]
    //public GameObject openUI;
    //public GameObject useUI;
    public Text uiText;
    public GameObject uiCam;

    public GameObject playerObj;

    [Header("Hide------------------------------")]
    CharacterController playerController;
    // public Animator hideCabinetAnim_1;
    // public Transform HideCabinetPos_1;
    //public Transform hidePosBed;
    //public Transform UnHidePos_1;
    //public Transform UnHidePos_2;


    [Header("Door----------------------------")]
    // public Animator unlockedDoor;
    bool dooropen;

    [Header("Drawer----------------------------")]
    public DrawerManager drawerManager;
    public Animator drawer_2;
    public bool isDrawerOpen2;
    bool isDrawerOpen1;
    bool isOpen;

    [Header("Items----------------------------")]
    public GameObject matches;
    public bool hasItem;
    public GameObject fire;
    public GameObject lpRecord;
    public bool hasItem2;
    public GameObject blueLense;
    bool hasitem3;

    public GameObject itemBox;
    public Animator itemBox1_Anim;

    public GameObject[] KeyObj;

    private void Start()
    {
        uiText.text = "";

        uiCam.SetActive(false);
        // useUI.SetActive(false);

        puzzle_UI = FindAnyObjectByType<Puzzle_UI>();
        keys = FindAnyObjectByType<Keys>();
        doorOpen = FindObjectOfType<Door_Open>();
        playerController = FindObjectOfType<CharacterController>();
        bunker_Enter = FindObjectOfType<Bunker_Enter>();
        uimanager = FindObjectOfType<UIManager>();
        //starter = FindObjectOfType<StarterAssetsInputs>();
        soundManager = FindObjectOfType<SoundManager>();
        hide_Scripts = FindObjectOfType<Hide>();
        turnon = FindObjectOfType<TurnOn>();
        battery = FindObjectOfType<BatteryCharge>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerRay();
    }

    private void PlayerRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            GameObject hitObject = hit.collider.gameObject;
            string objectTag = hitObject.tag;

            // print("오브젝트 : " + hitObject.name);

            if (objectTag != excludedTag)
            {
                //print("부딪힌 테그 : " + objectTag);

                //print("오브젝트 : " + hitObject.name);



                if (objectTag == "Ladder")
                {
                    uiText.text = "Use";

                    if (Input.GetMouseButtonDown(0))
                    {
                        playerController.enabled = false;

                        bunker_Enter.FadeMove();

                        if (bunker_Enter.isEndFadeMove)
                        {
                            playerController.enabled = true;
                        }

                    }
                }


                if (objectTag == "Item")
                {
                    uiText.text = hitObject.name;

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hitObject.name == "Blue Lense")
                        {
                            Destroy(blueLense);
                            keys.box1_Key.SetActive(true);
                            hasitem3 = true;
                        }

                        if (hitObject.name == "Rope")
                        {
                            Destroy(bunker_Enter.rope);
                            bunker_Enter.hasRope = true;
                        }

                        if (hitObject.name == "matches")
                        {
                            Destroy(matches);
                            // matches.SetActive(false);
                            hasItem = true;
                        }

                        if (hitObject.name == "Radio")
                        {
                            soundManager.radioAudio.PlayOneShot(soundManager.radioClip);
                        }


                        if (hitObject.name == "Lp_Record")
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                Destroy(lpRecord);
                                //lpRecord.SetActive(false);
                                hasItem2 = true;
                            }
                        }

                        if (hitObject.name == "battery")
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                hitObject.SetActive(false);

                                battery.BatteryCharges();
                            }
                        }
                    }

                }


                if (objectTag == "Keys")
                {
                    uiText.text = hitObject.name;

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hitObject.name == "Room2_Key" && keys.Room2_key != null)
                        {
                            Destroy(keys.Room2_key);
                            keys.hasRoom2Key = true;
                        }
                        else if (hitObject.name == "Room3_Key" && keys.Room3_key != null)
                        {
                            Destroy(keys.Room3_key);
                            keys.hasRoom3Key = true;
                        }
                        else if (hitObject.name == "box1_Key")
                        {
                            Destroy(keys.box1_Key);
                            keys.hasbox1_key = true;
                        }
                        else if (hitObject.name == "Escape_Key")
                        {
                            Destroy(keys.escapeKey);
                            keys.hasEscapeKey = true;
                        }

                    }


                }

                if (objectTag == "Lead")
                {
                    uiText.text = "Read";

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hitObject.name == "Lead1")
                        {
                            puzzle_UI.ToggleUI(puzzle_UI.Lead1);
                            puzzle_UI.Invoke("CloseUI", 2f);
                        }
                        else if (hitObject.name == "Lead2")
                        {
                            puzzle_UI.ToggleUI(puzzle_UI.Lead2);
                            puzzle_UI.Invoke("CloseUI", 2f);
                        }

                    }
                }

                if (objectTag == "Puzzle")
                {


                    if (hitObject.name == "PadLock")
                    {
                        uiText.text = "Open";

                        if (Input.GetMouseButtonDown(0))
                        {
                            uiText.enabled = false;
                            print("1");
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;

                            uiCam.SetActive(true);
                            uimanager.padlockUI.SetActive(true);
                            print("2");

                        }
                    }


                    if (hitObject.name == "Rack")
                    {
                        uiText.text = "lighting a fire";

                        if (hasItem && Input.GetMouseButtonDown(0))
                        {
                            fire.SetActive(true);
                            soundManager.Fireplacesound();

                            puzzle_UI.Invoke("OpenFireLead", 2f);
                            puzzle_UI.Invoke("CloseUI", 4f);

                        }
                    }


                    if (hitObject.name == "Lever")
                    {
                        uiText.text = "Use";

                        if (Input.GetMouseButtonDown(0))
                        {
                            if (bunker_Enter.isMove)
                            {
                                soundManager.LeverSound();
                                bunker_Enter.leverAnim.SetTrigger("Turn_On");

                                soundManager.FloorMove();
                                bunker_Enter.floorAnim.SetTrigger("Open");

                                bunker_Enter.isMove = false;
                            }

                        }

                    }


                    if (hitObject.name == "ItemBox")
                    {
                        uiText.text = "Open";

                        if (Input.GetMouseButtonDown(0))
                        {
                            if (keys.hasbox1_key)
                            {
                                itemBox1_Anim.SetTrigger("Open");
                            }
                        }
                    }

                }



                if (hitObject.tag == "Bunker")
                {
                    uiText.text = "Open";

                    if (Input.GetMouseButtonDown(0))
                    {
                        soundManager.BunkerOpen(); bunker_Enter.bunkerAnim.SetTrigger("Open");
                    }
                }


                if (objectTag == "Hide")
                {
                    uiText.text = "Hide/Out";

                    if (Input.GetMouseButtonDown(0))
                    {
                        playerController.enabled = false;

                        if (!Hide.isHide)
                        {

                            if (hitObject == hide_Scripts.cabinet1)
                            {
                                hide_Scripts.HideCabinet_1();
                            }
                            else if (hitObject == hide_Scripts.cabinet2)
                            {
                                hide_Scripts.HideCabinet_2();
                            }
                            else if (hitObject == hide_Scripts.cabinet3)
                            {
                                hide_Scripts.HideCabinet_3();
                            }
                            else if (hitObject == hide_Scripts.cabinet4)
                            {
                                hide_Scripts.HideCabinet_4();
                            }
                            else if (hitObject == hide_Scripts.cabinet5)
                            {
                                hide_Scripts.HideCabinet_5();
                            }

                        }
                        else
                        {
                            hitObject.GetComponent<Animator>().SetTrigger("Open");
                            Hide.isHide = false;
                            soundManager.isfearBreath = false;
                            playerController.enabled = true;
                        }
                    }
                }

                if (objectTag == "Bed")
                {
                    uiText.text = "Hide/Out";

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!Hide.isHide)
                        {

                            playerController.enabled = false;

                            if (hitObject == hide_Scripts.bed1)
                            {
                                hide_Scripts.HideBed1();
                            }
                            else if (hitObject == hide_Scripts.bed2)
                            {
                                hide_Scripts.HideBed2();
                            }
                            else if (hitObject == hide_Scripts.bed3)
                            {
                                hide_Scripts.HideBed3();
                            }
                            else if (hitObject == hide_Scripts.bed4)
                            {
                                hide_Scripts.HideBed4();
                            }
                            else if (hitObject == hide_Scripts.bed5)
                            {
                                hide_Scripts.HideBed5();
                            }
                        }
                        else
                        {

                            if (hitObject == hide_Scripts.bed1)
                            {
                                hide_Scripts.UnHideBed1();
                            }
                            else if (hitObject == hide_Scripts.bed2)
                            {
                                hide_Scripts.UnHideBed2();
                            }
                            else if (hitObject == hide_Scripts.bed3)
                            {
                                hide_Scripts.UnHideBed3();
                            }
                            else if (hitObject == hide_Scripts.bed4)
                            {
                                hide_Scripts.UnHideBed4();
                            }
                            else if (hitObject == hide_Scripts.bed5)
                            {
                                hide_Scripts.UnHideBed5();
                            }

                            playerController.enabled = true;
                        }
                    }
                }


                if (objectTag == "Cabinet")
                {
                    uiText.text = "USE";

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hitObject.name == "Hidden_Cabinet" && bunker_Enter.hasRope)
                        {
                            soundManager.cabinetMove();

                            bunker_Enter.cabienetAnim.SetTrigger("Move");
                            bunker_Enter.isMove = true;

                            //bunker_Enter.hasRope = false;
                        }
                    }
                }


                if (objectTag == "Drawer")
                {
                    uiText.text = "Open/Close";

                    Animator drawerAnimator = hit.collider.GetComponent<Animator>();

                    if (drawerAnimator != null && drawerManager.drawers.Contains(drawerAnimator))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (!isOpen)
                            {
                                drawerAnimator.SetBool("Open", true);
                                soundManager.OpenDrawerSound();
                                isOpen = true;
                            }
                            else
                            {
                                drawerAnimator.SetBool("Open", false);
                                soundManager.CloseDrawerSound();
                                isOpen = false;
                            }

                        }

                    }
                }

                //if (objectTag == "Drawer")
                //{
                //    uiText.text = "Open/Close";

                //    if (Input.GetMouseButtonDown(0))
                //    {
                //        if (hitObject.name == "Drawer1")
                //        {

                //            if (!isDrawerOpen1)
                //            {
                //                OpenDrawer();
                //            }
                //            else
                //            {
                //                CloseDrawer();
                //            }
                //        }

                //        if (hitObject.name == "b_door2")
                //        {

                //            if (!isDrawerOpen2)
                //            {
                //                bunker_Enter.door2Anim.SetBool("Open", true);
                //                isDrawerOpen2 = true;
                //            }
                //            else
                //            {
                //                bunker_Enter.door2Anim.SetBool("Open", false);
                //                isDrawerOpen2 = false;
                //            }
                //        }
                //    }
                //}

                if (objectTag == "unLockedDoor")
                {
                    uiText.text = "Open";

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (hitObject.name == "Room1_Door")
                        {
                            doorOpen.door1_Anim.SetTrigger("Open");
                            soundManager.Door1Audio.Play();
                        }

                        if (hitObject.name == "BathRoom_Door")
                        {

                            doorOpen.bathroom_Door_Anim.SetTrigger("Open");
                            soundManager.Door5Audio.Play();
                        }

                        if (hitObject.name == "Room4_Door")
                        {
                            doorOpen.door4_Anim.SetTrigger("Open");
                            soundManager.Door4Audio.Play();
                        }
                    }
                }
                else if (objectTag == "LockedDoor")
                {
                    uiText.text = "Open";

                    if (Input.GetMouseButtonDown(0))
                    {
                        doorOpen.OpenRoom();
                    }

                }



            }
            else
            {
                uiText.text = "";
            }
        }
        else
        {
            uiText.text = "";
        }
    }


    void OpenDrawer()
    {
        drawer_2.SetBool("Open", true);
        isDrawerOpen1 = true;
    }

    void CloseDrawer()
    {
        // 서랍을 닫고 상태를 닫힘으로 설정
        drawer_2.SetBool("Open", false);
        isDrawerOpen1 = false;
    }

}

