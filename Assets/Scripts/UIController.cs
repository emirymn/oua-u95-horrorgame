using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] Color textColor;
    [SerializeField] float alphaNum, alphaNumForKeyName;
    public TextMeshProUGUI MissionText, newItemNameText;
    public Image newItemImage, alertImg, keyboard;
    public GameObject blackScreen;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        alphaNumForKeyName = 0;
        newItemNameText.alpha = alphaNumForKeyName;
        StartCoroutine(MissionShow());
        StartCoroutine(KeyboardTutorial());

    }

    private void FixedUpdate()
    {
        MissionText.alpha = alphaNum;
        newItemNameText.alpha = alphaNumForKeyName;
    }

    public IEnumerator MissionShow()
    {
        bool isOpened = false;
        bool isFinished = false;
        alphaNum = 0;
        textColor.a = 255;
        textColor = Color.white;
        textColor.a = 0;
        yield return new WaitForSeconds(2f);
        while (!isOpened)
        {
            alphaNum += 0.01f;
            yield return new WaitForSeconds(0.02f);
            if (alphaNum >= 1)
            {
                isOpened = true;

                break;
            }
        }
        yield return new WaitForSeconds(2f);
        while (isOpened && !isFinished)
        {
            alphaNum -= 0.01f;
            yield return new WaitForSeconds(0.02f);
            if (alphaNum <= 0)
            {
                isFinished = true;
                break;
            }
        }
    }
    public IEnumerator KeyboardTutorial()
    {
        keyboard.DOFade(1f, 1f);
        yield return new WaitForSeconds(8f);
        keyboard.DOFade(0f, 1f);
    }
    public IEnumerator KeyNameShow()
    {
        bool isOpened = false;
        bool isFinished = false;
        alphaNumForKeyName = 0;
        textColor.a = 255;
        textColor = Color.white;
        textColor.a = 0;
        while (!isOpened)
        {
            alphaNumForKeyName += 0.01f;
            yield return new WaitForSeconds(0.06f);
            if (alphaNumForKeyName >= 1)
            {
                isOpened = true;

                break;
            }
        }
        yield return new WaitForSeconds(1.96f);
        while (isOpened && !isFinished)
        {
            alphaNumForKeyName -= 0.01f;
            yield return new WaitForSeconds(0.06f);
            if (alphaNumForKeyName <= 0)
            {
                isFinished = true;
                break;
            }
        }
    }
    public void KeyImageFadeOpen()
    {
        newItemImage.DOFade(1f, 2f).OnComplete(() =>
        {
            StartCoroutine(KeyImageFadeClose());
        });

    }
    IEnumerator KeyImageFadeClose()
    {
        yield return new WaitForSeconds(2f);
        newItemImage.DOFade(0f, 2f);
    }
    public void AlertUI(Image image)
    {
        image.DOKill(false);
        image.DOFade(1f, 1f);
    }
    public void AlertClose(Image image)
    {
        image.DOKill(false);
        image.DOFade(0f, 1f);
    }
    public void MissionTextUpdate(String stringText)
    {
        MissionText.text = stringText;
    }
}
