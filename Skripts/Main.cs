using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{
    bool IsSaying;
    bool IsFocus;
    bool IsConsoleType;
    public float sayingsec;
    public TextMeshProUGUI Texttarget;
    public TextMeshProUGUI consoletext;
    public GameObject mouthop;
    public GameObject mouthcl;
    public GameObject mouthFoc;
    public GameObject Texttarg;
    public float interval = 0.1f;

    IEnumerator OnType(string Say, bool isclear)
    {
        if (isclear)
            Texttarget.text = "";
        IsSaying = true;
        foreach (char item in Say)
        {
            Texttarget.text += item;
            yield return new WaitForSeconds(interval);
        }
        IsSaying = false;
    }
    IEnumerator Isconsoletype()
    {
        while (true)
        {
            if (IsConsoleType)
            {
                while (IsConsoleType)
                {
                    Texttarg.SetActive(true);
                }
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                Texttarg.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Texttarg.SetActive(true);
            }
            yield return null;
        }
    }
    IEnumerator ConsoleOnType(string Say, bool isclear)
    {
        if (isclear)
            consoletext.text = "C:/ponopoyo.p>>> ";
        IsConsoleType = true;
        foreach (char item in Say)
        {
            consoletext.text += item;
            yield return new WaitForSeconds(interval);
        }
        IsConsoleType = false;
    }
    void Startset()
    {
        if (IsFocus)
        {
            mouthop.SetActive(false);
            mouthFoc.SetActive(true);
            mouthcl.SetActive(false);
        }
        else
        {
            mouthop.SetActive(true);
            mouthFoc.SetActive(false);
            mouthcl.SetActive(false);
        }
    }
    IEnumerator consoletypein()
    {
        StartCoroutine(ConsoleOnType("start main texts", false));
        yield return null;
    }
    IEnumerator Maintext()
    {
        IsFocus = true;
        yield return new WaitForSeconds(3f);
        StartCoroutine(OnType("오 드디어 내 속이 가득찬 이 기분", false));

    }
    void Start()
    {
        StartCoroutine(Isconsoletype());
        StartCoroutine(Saying());
        StartCoroutine(Maintext());
        Startset();
    }

    IEnumerator Saying()
    {
        while (true)
        {
            if (IsSaying)
            {
                    mouthop.SetActive(false);
                    mouthFoc.SetActive(false);
                    mouthcl.SetActive(false);

                if (IsFocus)
                {
                    while (IsSaying)
                    {
                        mouthFoc.SetActive(false);
                        mouthcl.SetActive(true);
                        yield return new WaitForSeconds(sayingsec);
                        mouthFoc.SetActive(true);
                        mouthcl.SetActive(false);
                        yield return new WaitForSeconds(sayingsec);
                    }
                }
                else
                {
                    while (IsSaying)
                    {
                        mouthop.SetActive(false);
                        mouthcl.SetActive(true);
                        yield return new WaitForSeconds(sayingsec);
                        mouthop.SetActive(true);
                        mouthcl.SetActive(false);
                        yield return new WaitForSeconds(sayingsec);
                    }
                }
                if (IsFocus)
                {
                    mouthop.SetActive(false);
                    mouthFoc.SetActive(true);
                    mouthcl.SetActive(false);
                }
                else
                {
                    mouthop.SetActive(true);
                    mouthFoc.SetActive(false);
                    mouthcl.SetActive(false);
                }

            }

            yield return null;
        }
    }

}
