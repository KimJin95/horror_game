using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Enter : MonoBehaviour
{
    public GameObject slenderMan;
    Door_Open doorScripts;

    AudioClip door_Open_Close;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (slenderMan != null)
        {
            if (collision.gameObject.tag == "Monster")
            {
                print("1");
                if (this.gameObject.name == "Room1_Door")
                {
                    doorScripts.door1_Anim.SetTrigger("Open");
                }
                else if (this.gameObject.name == "Room2_Door")
                {
                    doorScripts.door2_Anim.SetTrigger("Open");
                }
                else if (this.gameObject.name == "Room3_Door")
                {
                    doorScripts.door3_Anim.SetTrigger("Open");
                }
                else if (this.gameObject.name == "Room4_Door")
                {
                    doorScripts.door4_Anim.SetTrigger("Open");
                }
            }
        }
    }
}
