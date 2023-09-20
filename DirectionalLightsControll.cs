using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightsControll : MonoBehaviour
{
  
    void Start()
    {
        this.gameObject.transform.rotation = Quaternion.Euler(-10, -30, 0);
    }

}
