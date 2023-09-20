using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;

    [Header("ItemSound-----------")]
    public GameObject[] items; // 아이템을 저장할 배열
    public AudioSource soundSource; // 사운드 재생을 위한 AudioSource
    public AudioClip nullItemSound; // null 아이템 발견 시 재생할 사운드

    private bool[] itemPlayed; // 각 아이템의 재생 여부를 추적하기 위한 배열

    [Header("Setting-------------")]
    public GameObject SettingUIPanel;
    public GameObject KeyUI;


    void Start()
    {       

        // 아이템 배열의 크기에 맞춰 재생 여부 배열 초기화
        itemPlayed = new bool[items.Length];
        SettingUIPanel.SetActive(false);
        KeyUI.SetActive(true);
    }

    void Update()
    {
        ItemNullCheck();
        SettingPanel();
        KeyManual();
    }

    private void ItemNullCheck()
    {
        // 아이템 배열을 검사하여 null 아이템이 있는지 확인
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null && !itemPlayed[i])
            {
                // null 아이템을 발견하고 아직 재생되지 않은 경우 사운드를 재생하고 플래그를 설정
                soundSource.PlayOneShot(nullItemSound);
                itemPlayed[i] = true;
            }
        }
    }

    public void ReStartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainSceneBtn()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    private void SettingPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingUIPanel.SetActive(true);
        }
    }

    private void KeyManual()
    {
        Destroy(KeyUI, 2f);
    }


}








