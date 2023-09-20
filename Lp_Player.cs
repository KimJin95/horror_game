using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lp_Player : MonoBehaviour
{
    Camera_Ray camRay;

    public GameObject lp;
    public GameObject lp2;

    public Animator playLpAnim;
    public Animator door_W_Anim1;
    public Animator door_W_Anim2;

    public Collider boxColi;

    void Start()
    {
        camRay = FindObjectOfType<Camera_Ray>();
        // playLpAnim = GameObject.Find("Handle").GetComponent<Animator>();
        //door_W_Anim1 = GameObject.Find("Hidden_door1_low").GetComponent<Animator>();
        // door_W_Anim2 = GameObject.Find("Hidden_door2_low").GetComponent<Animator>();

    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (lp == null)
        {
            boxColi.enabled = false;
            lp2.SetActive(true);

            playLpAnim.SetTrigger("Play");

            door_W_Anim1.SetTrigger("Open");
            door_W_Anim2.SetTrigger("Open");
        }
    }
}
