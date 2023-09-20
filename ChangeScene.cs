using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject camBox;
    GameObject Bgm;

    private void Start()
    {
        Bgm = GameObject.Find("BGM");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == camBox)
        {
            Invoke("NextScene", 1f);
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene("Main Scene");
        Destroy(Bgm);
        
    }
}
