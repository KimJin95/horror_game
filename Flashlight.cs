using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    UIManager uiManager;

    [Header("Flashlight")]
    public Light flashlight;
    //public bool isLightOn = false;

    public float consumptionRateTerSec = 0.5f;
    public float rechargeRate = 25f;

   // private bool hasBattery;
    private Battery battery;

    void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();
        battery = new Battery(100f);

    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
  
        ConsumeBattery(deltaTime);

        BatteryUI();
    }


    private void ConsumeBattery(float deltaTime)
    {
        float consumptionAmount = consumptionRateTerSec * deltaTime;
        battery.Consume(consumptionAmount);
       // print("���͸� �Ҹ���. ���� ���͸� : " + battery.CurrentCapacity);

    }


    public void RechargeBattery()
    {

        float rechargeAmount = rechargeRate;
        battery.Recharge(rechargeAmount);
        Debug.Log("���͸� �����Ϸ�. Remaining capacity: " + battery.CurrentCapacity);
    }

    public void BatteryUI()
    {

        if (battery.CurrentCapacity > 75)
        {
            uiManager.full_Battery.SetActive(true);
            uiManager.high_Battery.SetActive(false);
            uiManager.medium_Battery.SetActive(false);
            uiManager.low_Battery.SetActive(false);
            uiManager.empty_Battery.SetActive(false);
        }
        else if (battery.CurrentCapacity > 50)
        {
            uiManager.full_Battery.SetActive(false);
            uiManager.high_Battery.SetActive(true);
            uiManager.medium_Battery.SetActive(false);
            uiManager.low_Battery.SetActive(false);
            uiManager.empty_Battery.SetActive(false);
        }

        else if (battery.CurrentCapacity > 20)
        {
            uiManager.full_Battery.SetActive(false);
            uiManager.high_Battery.SetActive(false);
            uiManager.medium_Battery.SetActive(true);
            uiManager.low_Battery.SetActive(false);
            uiManager.empty_Battery.SetActive(false);
        }

        else if (battery.CurrentCapacity > 0)
        {
            uiManager.full_Battery.SetActive(false);
            uiManager.high_Battery.SetActive(false);
            uiManager.medium_Battery.SetActive(false);
            uiManager.low_Battery.SetActive(true);
            uiManager.empty_Battery.SetActive(false);
        }

        else if (battery.CurrentCapacity == 0)
        {
            uiManager.full_Battery.SetActive(false);
            uiManager.high_Battery.SetActive(false);
            uiManager.medium_Battery.SetActive(false);
            uiManager.low_Battery.SetActive(false);
            uiManager.empty_Battery.SetActive(true);

            flashlight.enabled = false;
        }
    }


}
