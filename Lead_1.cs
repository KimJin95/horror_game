using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ProBuilder.MeshOperations;

public class Lead_1 : MonoBehaviour
{
    private MouseCursor mouseCursor;

    UIManager uiManager;

    public GameObject[] LeadUI;
    public GameObject[] LeadObjects;

    public bool isRead;

    //public GameObject uiObject1;
    //public GameObject uiObject2;
    //// �߰� UI ������Ʈ��...

    private GameObject currentUI;

    private void Start()
    {
        // �ʱ�ȭ: ��� UI�� ��Ȱ��ȭ
        LeadUI[0].SetActive(false);
        LeadUI[1].SetActive(false);
        LeadUI[2].SetActive(false);
        LeadUI[3].SetActive(false);
        LeadUI[4].SetActive(false);
        //LeadUI[5].SetActive(false);
        // �߰� UI ������Ʈ�� ��Ȱ��ȭ...
    }

    private void ShowUI(GameObject uiObject)
    {
        if (currentUI != null)
        {
            currentUI.SetActive(false); // ���� UI�� ��Ȱ��ȭ
        }

        currentUI = uiObject;
        currentUI.SetActive(true); // ���ο� UI Ȱ��ȭ
    }

    //private void OnMouseDown()
    //{
    //    if (gameObject.name=="Lead0")
    //    {
    //        print("7");

    //        ShowUI(LeadUI[0]);
    //    }
    //    else if (gameObject == LeadObjects[1])
    //    {
    //        ShowUI(LeadUI[1]);
    //    }
    //    else if(gameObject == LeadObjects[2])
    //    {
    //        ShowUI(LeadUI[2]);
    //    }
    //    else if(gameObject== LeadObjects[3])
    //    {
    //        print("2");
    //        ShowUI(LeadUI[3]);
    //    }
    //    else if (gameObject.name == "Lead4")
    //    {
    //        ShowUI(LeadUI[4]);
    //    }
    //    else if( gameObject == LeadObjects[5])  
    //    {
    //        ShowUI(LeadUI[5]);
    //    }
    //    // �߰� UI ������Ʈ�鿡 ���� ó��...
    //}


}
