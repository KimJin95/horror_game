using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Intro_UI : MonoBehaviour
{
    [Header("UI---------------------")]
    public GameObject title;
    public GameObject menu;
    public GameObject door;
    public GameObject title2;

    private Coroutine currentCoroutine;


    public bool isStart = false;
    bool isPopup;

    AudioSource myAudio;
    public AudioClip slamClip;

    public GameObject BGM;
    AudioSource BGMAudio;

    private void Awake()
    {
        BGMAudio = BGM.GetComponent<AudioSource>();


        DontDestroyOnLoad(BGM);

    }

    void Start()
    {
        isStart = false;
        myAudio = GetComponent<AudioSource>();
        BGMAudio = BGM.GetComponent<AudioSource>();

        //if (SceneManager.GetActiveScene().name == "Main Scene")
        //{
        //    Destroy(this.gameObject);
        //}


    }


    void Update()
    {
        PopupTitle();

        if (title2.activeSelf && !isPopup)
        {
            myAudio.clip = slamClip; myAudio.Play();

            isPopup = true;
        }
    }

    public void PressStartBtn()
    {
        title.SetActive(false);
        menu.SetActive(false);

        isStart = true;
    }

    private void PopupTitle()
    {
        if (door == null)
        {
            title2.SetActive(true);

            Invoke("ChangeScene", 2f);

        }

    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Masion scene");


    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
