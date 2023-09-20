using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DooropenSound : MonoBehaviour
{
    AudioSource myAudio;
    public AudioClip doorOpenAndClose;

    bool isopen;
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Monster") && !isopen)
        {
            print("3");
            myAudio.clip = doorOpenAndClose;
            myAudio.Play();

            isopen = false;
            print("4");
            Destroy(this.gameObject, 3f);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Monster") && !isopen)
    //    {
    //        print("3");

    //        myAudio.clip = doorOpenAndClose;
    //        myAudio.Play(); 

    //        isopen = false;
    //        print("4");
    //    }
    //}
}
