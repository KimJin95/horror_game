using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Bunker_Enter : MonoBehaviour
{
    [Header("Object")]
    public GameObject rope;
    public bool hasRope;
    public GameObject cabinet;
    public bool isMove;
    public GameObject floor;
    public GameObject bunker;

    [Header("Animator")]
    public Animator door2Anim;
    public Animator cabienetAnim;
    public Animator floorAnim;
    public Animator bunkerAnim;
    public Animator leverAnim;
    public Animator blackUIAnim;

    [Header("Bunker")]
    public GameObject ladder;
    public Transform playerObjPresentPos;
    public Transform playerObjmMovePos;

    public GameObject BlackUI;
    public Image blackImage;

    public bool isEndFadeMove;


    SoundManager soundManager;

    void Start()
    {
        BlackUI.SetActive(false);
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeMove()
    {
        FadeInAnim();
        Invoke("PlayerPos", 1.5f);
        soundManager.Invoke("UseLadder", 2f);
        Invoke("FadeOutAnim", 4f);

        isEndFadeMove = true;
    }

    public void FadeInAnim()
    {
        blackUIAnim.SetBool("Fade", true);
    }

    public void FadeOutAnim()
    {
        blackUIAnim.SetBool("Fade", false);
    }

    public void PlayerPos()
    {
        playerObjPresentPos.position = playerObjmMovePos.position;
    }
    //public void FadeOut()
    //{
    //    StartCoroutine(FadeOutCoroutine());

    //}
    //public void FadeIn()
    //{
    //    StartCoroutine(FadeInCorouttine());
    //    playerObjPresentPos.position = playerObjmMovePos.position;
    //}

    //IEnumerator FadeOutCoroutine()
    //{
    //    float fadeCount = 0;
    //    while (fadeCount < 1.0f)
    //    {
    //        print("out");
    //        fadeCount += 0.01f;
    //        yield return new WaitForSeconds(0.01f);

    //        blackImage.color = new Color(0, 0, 0, fadeCount);
    //    }

    //}

    //IEnumerator FadeInCorouttine()
    //{
    //    float fadeCount = 1;

    //    while (fadeCount >= 1.0f)
    //    {
    //        fadeCount -= 0.01f;
    //        yield return new WaitForSeconds(1f);

    //        blackImage.color = new Color(0, 0, 0, fadeCount);
    //        print("in");
    //    }

    //    isEndFadeIn = true;
    //}
}
