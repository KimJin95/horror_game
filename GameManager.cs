using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SoundManager soundManager;

    [Header("ItemSound-----------")]
    public GameObject[] items; // �������� ������ �迭
    public AudioSource soundSource; // ���� ����� ���� AudioSource
    public AudioClip nullItemSound; // null ������ �߰� �� ����� ����

    private bool[] itemPlayed; // �� �������� ��� ���θ� �����ϱ� ���� �迭

    [Header("Setting-------------")]
    public GameObject SettingUIPanel;
    public GameObject KeyUI;


    void Start()
    {       

        // ������ �迭�� ũ�⿡ ���� ��� ���� �迭 �ʱ�ȭ
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
        // ������ �迭�� �˻��Ͽ� null �������� �ִ��� Ȯ��
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null && !itemPlayed[i])
            {
                // null �������� �߰��ϰ� ���� ������� ���� ��� ���带 ����ϰ� �÷��׸� ����
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








