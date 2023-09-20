using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password_2 : MonoBehaviour
{
    [Header("NumberBtn---------------")]
    public Text textBlank1;
    public Text textBlank2;
    public Text textBlank3;
    public Text textBlank4;

    [Header("Text---------------")]
    public string numText1="1";
    public string numText2 = "2";
    public string numText3 = "3";
    public string numText4 = "4";
    public string numText5 = "5";
    public string numText6 = "6";
    public string numText7 = "7";
    public string numText8 = "8";
    public string numText9 = "9";
    public string numText0 = "0";
    public string numText10 = "*";
    public string numText11 = "#";


    private bool Count1;
    private bool Count2;
    private bool Count3;
    private bool Count4;

    public void ButtonClicked1()
    {
        //if(!Count1&&!Count2)
        textBlank1.text = numText1;
    }
    public void ButtonClicked2()
    {
        textBlank2.text = numText2;
    }
    public void ButtonClicked3()
    {
        textBlank3.text = numText3;
    }
    public void ButtonClicked4()
    {
        textBlank4.text = numText4;
    }
    
}
