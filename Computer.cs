using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject Com;

    void Start()
    {
        Com.SetActive(false);
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {
        Com.SetActive(true);
    }

}
