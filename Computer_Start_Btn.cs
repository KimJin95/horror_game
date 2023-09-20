using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class Computer_Start_Btn : MonoBehaviour
{
    public GameObject pressBtn;
    public GameObject shotdownBtn;

    public bool isStart;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isStart)
            {
                this.gameObject.SetActive(false);

                pressBtn.SetActive(true);
                shotdownBtn.SetActive(true);
            }
        }
    }

}






