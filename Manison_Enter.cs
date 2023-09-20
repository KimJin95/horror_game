using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Manison_Enter : MonoBehaviour
{
    public GameObject enterUI;
    public float destroyTime = 25f;
    public GameObject lights1;
    public GameObject lights2;

    private AudioSource myAudio;

    [Header("TextTyping--------------------")]
    public TMP_Text warningText;
    string dialogue;

    [Header("Door--------------------------")]
    public GameObject leftDoor;
    public GameObject rightDoor;
    Animator leftDoorAnim;
    Animator rightDoorAnim;
    AudioSource rightDoorSound;

    private CharacterController playerController;

    void Start()
    {

        enterUI.SetActive(false);

        dialogue = "If you're reading this, that means you're in 'THE HOUSE'.\r\n" +
            "Find only one way to escape\r\n" +
            "Good luck\r\n\r\n" +
            "P.S. Be careful not to get caught by the owner of the house";

        myAudio = gameObject.GetComponent<AudioSource>();

        leftDoorAnim = leftDoor.GetComponent<Animator>();
        rightDoorAnim = rightDoor.GetComponent<Animator>();
        rightDoorSound = rightDoor.GetComponent<AudioSource>();

        playerController = GameObject.FindAnyObjectByType<CharacterController>();
    }

    //void Update()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            Destroy(lights1);
            Destroy(lights2);
            //lights1.SetActive(false); lights2.SetActive(false);

            leftDoorAnim.SetTrigger("Enter");
            rightDoorAnim.SetTrigger("R_Enter");
            rightDoorSound.Play();

            enterUI.SetActive(true);
            StartCoroutine(Typing(dialogue));
            myAudio.Play();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Destroy(this.gameObject, destroyTime);
        }
    }


    IEnumerator Typing(string warningWords)
    {
        warningText.text = null;

        for (int i = 0; i < warningWords.Length; i++)
        {
            warningText.text += warningWords[i];

            yield return new WaitForSeconds(0.1f);
        }

        myAudio.Stop();
    }

    public void SkipBtn()
    {
        Destroy(this.gameObject);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
