using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class password : MonoBehaviour
{
    [Header("Sprite-----------------")]
    public Sprite[] numbers;
    private Sprite myImage;

    public Image number1;
    public Image number2;
    public Image number3;

    [Header("Code-----------------")]
    private int maxCount = 9;
    private int minCount = 0;
    public int count1;
    public int count2;
    public int count3;
    public int[] currentCode;
    public int[] targetCode;

    private Keys keys;


    [Header("Code-----------------")]
    public Animator CubeAnim;


    [Header("Door-----------------")]
    public Collider door_1_Collider;

    public bool unLocked = false;

    void Start()
    {

        // myImage = gameObject.GetComponent<Image>().sprite;
        // myImage = numbers[0];

        // number1 = GameObject.Find("Number1").GetComponent<Image>();
        number1.sprite = numbers[0];
        number2.sprite = numbers[0];
        number3.sprite = numbers[0];
        // number2 = GameObject.Find("Number2").GetComponent<Image>();
        // number3 = GameObject.Find("Number3").GetComponent<Image>();
    }

    private void Update()
    {
        CurrectCode();
        //AfterDooropen();
    }

    public void ChangingNum1()
    {
        print("1");

        count1 = (count1 + 1) % numbers.Length;

        if (count1 < 0)
        {
            count1 += numbers.Length;
        }

        if (number1.sprite != null)
        {
            number1.sprite = numbers[count1];
        }

        currentCode[0] = count1;

    }

    public void ChangingNum2()
    {
        count2 = (count2 + 1) % numbers.Length;

        if (count2 < 0)
        {
            count2 += numbers.Length;
        }

        if (number2.sprite != null)
        {
            number2.sprite = numbers[count2];
        }

        currentCode[1] = count2;
    }

    public void ChangingNum3()
    {
        count3 = (count3 + 1) % numbers.Length;

        if (count3 < 0)
        {
            count3 += numbers.Length;
        }

        if (number3.sprite != null)
        {
            number3.sprite = numbers[count3];
        }

        currentCode[2] = count3;
    }


    public void OpenDoor()
    {

        CubeAnim.SetBool("open", true);

    }

    private void CurrectCode()
    {
        if (currentCode[0] == targetCode[0] &&
            currentCode[1] == targetCode[1] &&
            currentCode[2] == targetCode[2])
        {

            OpenDoor();

            unLocked = true;
        }


    }

    //public void AfterDooropen()
    //{
    //    if (keys.hasKey)
    //    {
    //        if (!keys.key_1.activeSelf)
    //        {
    //            CubeAnim.SetBool("open", true);
    //        }
    //    }
    //}

}
