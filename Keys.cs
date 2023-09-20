using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    [Header("Rooms--------------------")]
    public GameObject Room2_key;
    public bool hasRoom2Key = false;

    public GameObject Room3_key;
    public bool hasRoom3Key = false;

    public GameObject escapeKey;
    public bool hasEscapeKey = false;

    [Header("Box----------------------")]
    public GameObject box1_Key;
    public bool hasbox1_key;


    void Start()
    {
        box1_Key.SetActive(false);

    }

    void Update()
    {


    }

  

}
