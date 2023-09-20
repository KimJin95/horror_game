using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BatteryCharge : MonoBehaviour
{
    private Flashlight flashlight;
    UIManager uiManager;

    public static bool hasbattery;

    private void Start()
    {
        flashlight = GameObject.FindObjectOfType<Flashlight>();

        uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnMouseDown()
    {
        //if (uiManager.openImagePanel.activeSelf)
        //{
        //    this.gameObject.SetActive(false);

        //    hasbattery = true;

        //    flashlight.RechargeBattery();
        //    hasbattery = false;

        //}
    }

    public void BatteryCharges()
    {
        hasbattery = true;

        flashlight.RechargeBattery();
        hasbattery = false;
    }
}
