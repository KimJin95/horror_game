using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    GameObject Enemy;

    void Start()
    {
        Enemy = GameObject.FindWithTag("Monster");

        Enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Enemy.SetActive(true);
        }
    }
}
