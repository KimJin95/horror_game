using System.Collections;
using System.Collections.Generic;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("mouse------------------")]
   // public GameObject hidePanel;
  //public GameObject escapePanel;

    int count = 0;

    [Header("HP---------------------")]
    public GameObject hp_Image_1;
    public GameObject hp_Image_2;
    public GameObject hp_Image_3;

    [Header("Flashlight-------------")]
    private Battery battery;

    public GameObject full_Battery;
    public GameObject high_Battery;
    public GameObject medium_Battery;
    public GameObject low_Battery;
    public GameObject empty_Battery;

    [Header("lock-------------------")]
    public GameObject padlockUI;


    private void Start()
    {
       // hidePanel.SetActive(false);
        padlockUI.SetActive(false);
    }

    private void Update()
    {
 
    }

    public void TakeDamage()
    {
        if (count == 0)
        {
            hp_Image_1.SetActive(true);
            count++;
        }

        else if (count == 1 && hp_Image_1.activeSelf)
        {
            hp_Image_2.SetActive(true);
            count++;
        }

        else if (count == 2 && hp_Image_2.activeSelf == true)
        {
            hp_Image_3.SetActive(true);
            count++;
        }
    }

    //public void TakePill()
    //{
    //    if (count == 1 && hp_Image_1.activeSelf)
    //    {
    //        hp_Image_1.SetActive(false);
    //        count--;
    //    }

    //    else if (count == 2 && hp_Image_2.activeSelf)
    //    {
    //        hp_Image_2.SetActive(false);
    //        count--;
    //    }

    //    else if (count == 3 && hp_Image_3.activeSelf)
    //    {
    //        hp_Image_1.SetActive(false);
    //        count--;
    //    }
    //}

    public void BatteryUI()
    {
        if (battery.CurrentCapacity > 75)
        {
            full_Battery.SetActive(true);
            high_Battery.SetActive(false);
            medium_Battery.SetActive(false);
            low_Battery.SetActive(false);
            empty_Battery.SetActive(false);
        }
        else if (battery.CurrentCapacity > 50)
        {
            full_Battery.SetActive(false);
            high_Battery.SetActive(true);
            medium_Battery.SetActive(false);
            low_Battery.SetActive(false);
            empty_Battery.SetActive(false);
        }
        else if (battery.CurrentCapacity > 20)
        {
            full_Battery.SetActive(false);
            high_Battery.SetActive(false);
            medium_Battery.SetActive(true);
            low_Battery.SetActive(false);
            empty_Battery.SetActive(false);
        }
        else if (battery.CurrentCapacity > 0)
        {
            full_Battery.SetActive(false);
            high_Battery.SetActive(false);
            medium_Battery.SetActive(false);
            low_Battery.SetActive(true);
            empty_Battery.SetActive(false);
        }
        else if (battery.CurrentCapacity == 0)
        {
            full_Battery.SetActive(false);
            high_Battery.SetActive(false);
            medium_Battery.SetActive(false);
            low_Battery.SetActive(false);
            empty_Battery.SetActive(true);
        }
    }


}
