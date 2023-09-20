using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Move : MonoBehaviour
{
    Intro_UI intro_UI;

    Animator myAnim;
    private AudioSource myAudio;
    public AudioClip walkClip;


    public float walkTimeing;
    public bool isMove = false;

    public AudioClip doorOpenAndClose;

    bool isopen;


    void Start()
    {
        isMove = false;
        intro_UI = FindObjectOfType<Intro_UI>();
        myAnim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (intro_UI.isStart)
        {

            myAnim.SetTrigger("Start");
            isMove = true;

            Invoke("SoundEffect", walkTimeing);
        }

    }


    private void SoundEffect()
    {

        myAudio.clip = walkClip;
        myAudio.Play();

        intro_UI.isStart = false;
    }

}
