using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class padlockAnim : MonoBehaviour
{
    UIManager uimanager;
    StarterAssetsInputs starter;
    Camera_Ray rayCam;

    public Animator padlockAnimator1;
    public Animator padlockAnimator2;
    public Animator padlockAnimator3;
    public AnimationClip[] animations;

    public bool isAnimating;

    public Animator boxAnim;
    public GameObject padlockObj1;
    public GameObject padlockObj2;
    public Collider boxCollider;

    private int AnimCount1 = 0;
    private int AnimCount2 = 0;
    private int AnimCount3 = 0;

    public int[] currentCode;
    public int[] targetCode;

    SoundManager soundManager;

    private void Start()
    {
        uimanager = FindObjectOfType<UIManager>();
        starter = FindObjectOfType<StarterAssetsInputs>();
        rayCam = FindObjectOfType<Camera_Ray>();
        soundManager = FindObjectOfType<SoundManager>();

    }

    private void Update()
    {
        if (currentCode[0] == targetCode[0] &&
            currentCode[1] == targetCode[1] &&
            currentCode[2] == targetCode[2])
        {
            soundManager.padlockAudio.Play();
            Invoke("FalseTime", 1f);

            boxAnim.SetTrigger("Open");
            boxCollider.enabled = false;

            Destroy(padlockObj1);
            padlockObj2.SetActive(true);

            rayCam.uiText.enabled = true;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void FalseTime()
    {
        rayCam.uiCam.SetActive(false);
        uimanager.padlockUI.SetActive(false);
    }
    public void ButtonClicked1()
    {

        if (AnimCount1 < animations.Length)
        {
            padlockAnimator1.Play(animations[AnimCount1].name);
            AnimCount1++;
            isAnimating = false;

            currentCode[0] = AnimCount1;
        }
        else
        {
            AnimCount1 = 0;

        }
    }

    public void ButtonClicked2()
    {

        if (AnimCount2 < animations.Length)
        {
            padlockAnimator2.Play(animations[AnimCount2].name);
            AnimCount2++;
            isAnimating = false;

            currentCode[1] = AnimCount2;
        }
        else
        {
            AnimCount2 = 0;

        }

    }

    public void ButtonClicked3()
    {

        if (AnimCount3 < animations.Length)
        {
            padlockAnimator3.Play(animations[AnimCount3].name);
            AnimCount3++;
            isAnimating = false;

            currentCode[2] = AnimCount3;
        }
        else
        {
            AnimCount3 = 0;

        }

    }

    public void BackBtn()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        rayCam.uiCam.SetActive(false);
        uimanager.padlockUI.SetActive(false);
    }

}
