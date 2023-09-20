using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource myAudio;

    public GameObject MonsterPos;
    public GameObject PlayerPos;
    public float distanceThreshold = 5f;

    public AudioClip HeartbeatClip;
    int loopdist = 40;
    bool isPlay = false;

    [Header("DoorSound-------------")]
    public AudioSource Door1Audio;
    public AudioSource Door2Audio;
    public AudioSource Door3Audio;
    public AudioSource Door4Audio;
    public AudioSource Door5Audio;

    public AudioClip doorslamClip;
    public AudioClip lockedClip;
    //public AudioClip unlockedClip;
    public AudioClip EscapeDoorClip;

    [Header("Player-----------------")]
    public AudioSource playerAudio;
    public AudioClip foorstepClip;

    public AudioClip fearbreathClip;
    public AudioClip getItemClip;
    public bool isfearBreath;

    [Header("Monster-----------------")]
    public AudioSource monsterAudio;
    // public AudioClip footstepClip_;
    // public AudioClip attackClip;
    // public AudioClip howlinglClip;

    [Header("Fire-------------------")]
    public AudioSource fire;
    public AudioClip firematchclip;
    [Header("Radio-------------------")]
    public AudioSource radioAudio;
    public AudioClip radioClip;
    [Header("Puzzle-------------------")]
    public AudioSource padlockAudio;
    public AudioClip lenseBrokeClip;
    [Header("StudyRoom-------------------")]
    public AudioClip furnitureMoveClip;
    public AudioClip leverClip;
    public AudioClip woodFloorOpenClip;
    public AudioClip bunkerOpenClip;
    public AudioClip ladderClip;
    [Header("StudyRoom-------------------")]
    public AudioClip DrawerOpenClip;
    public AudioClip DrawerCloseClip;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        HeartbeatSound();
        HideBreath();
    }

    private void HeartbeatSound()
    {
        float distance = Vector3.Distance(MonsterPos.transform.position, PlayerPos.transform.position);


        if (distance <= distanceThreshold)
        {
            if (!isPlay)
            {
                monsterAudio.clip = HeartbeatClip;
                monsterAudio.Play();
                monsterAudio.loop = true;

                isPlay = true;
            }
        }
        else
        {
            if (loopdist < distance)
            {
                monsterAudio.loop = false;
                isPlay = false;
            }
        }

    }

    public void Fireplacesound()
    {
        fire.PlayOneShot(firematchclip);
    }

    private void HideBreath()
    {
        if (Hide.isHide && !isfearBreath)
        {
            myAudio.volume = 0.5f;
            myAudio.loop = false;

            myAudio.clip = fearbreathClip;
            myAudio.PlayOneShot(fearbreathClip);
 
            isfearBreath = true;

        }
    }

    public void EscapeDoorOpen()
    {
        myAudio.clip = EscapeDoorClip;
        myAudio.Play();
    }

    public void OpenDrawerSound()
    {
        myAudio.clip = DrawerOpenClip;
        myAudio.Play();
    }
    public void CloseDrawerSound()
    {
        myAudio.clip = DrawerCloseClip;
        myAudio.Play();
    }


    public void LockedDoor()
    {
        myAudio.clip = lockedClip;
        myAudio.Play();
    }

    public void LenseBroke()
    {
        myAudio.clip = lenseBrokeClip; myAudio.Play();
    }

    public void cabinetMove()
    {
        myAudio.clip = furnitureMoveClip; myAudio.Play();
    }

    public void LeverSound()
    {
        myAudio.clip = leverClip; myAudio.Play();
    }

    public void FloorMove()
    {
        myAudio.clip = woodFloorOpenClip; myAudio.Play();
    }

    public void BunkerOpen()
    {
        myAudio.clip = bunkerOpenClip; myAudio.Play();
    }

    public void UseLadder()
    {
        myAudio.clip = ladderClip; myAudio.Play();
    }
}
