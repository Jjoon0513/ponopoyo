using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{
    bool IsSaying;
    bool IsFocus;
    bool Isconsoleactive = true;
    public float sayingsec;
    public TextMeshProUGUI Texttarget;
    public TextMeshProUGUI consoletext;
    public GameObject eyes;
    public GameObject mouthop;
    public GameObject mouthcl;
    public GameObject mouthFoc;
    public GameObject Texttarg;
    public float interval = 0.1f;

    private void Update()
    {
        if (Isconsoleactive)
        {
            Texttarg.SetActive(true);
        }
        else
        {
            Texttarg.SetActive(false);
        }
    }

    IEnumerator OnTypeLine(string Say)
    {
        IsSaying = true;
        foreach (char item in Say)
        {
            Texttarget.text += item;
            yield return new WaitForSeconds(interval);
        }
        IsSaying = false;
        yield return new WaitForSeconds(1f);
        cls();
    }
    IEnumerator OnType(string Say)
    {
        IsSaying = true;
        foreach (char item in Say)
        {
            Texttarget.text += item;
            yield return new WaitForSeconds(interval);
        }
        IsSaying = false;
    }
    IEnumerator ConsoleOnType(string Say, bool isclear)
    {
        if (isclear)
            consoletext.text = "C:/ponopoyo.p>>> ";
        foreach (char item in Say)
        {
            consoletext.text += item;
            yield return new WaitForSeconds(interval);
        }
        consolecls();
    }

    void consolecls()
    {
        consoletext.text = "C:/ponopoyo.p>>> ";
    }
    void cls()
    {
       Texttarget.text = "";
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


    public void Eyemove(float posx, float posy, bool isadd)
    {
        Vector3 oldpos;

        if (isadd)
        {
            oldpos = eyes.transform.position;
            oldpos.x = oldpos.x + posx;
            oldpos.y = oldpos.y + posy;
            oldpos.z = -3;
            eyes.transform.position = oldpos;
        }
        else
        {
            eyes.transform.position = new Vector3(posx, posy, -3);
        }
    }
    IEnumerator consoletypein()
    {
        yield return StartCoroutine(ConsoleOnType(" start main texts", false));
        yield return new WaitForSeconds(4);
        yield return StartCoroutine(ConsoleOnType(" set ponopoyo.p = {GetReturnposComset}comp. <132059161928739587192837>", false));
        yield return new WaitForSeconds(4);
    }

    IEnumerator Maintext()
    {
        IsFocus = true;
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(OnTypeLine("오 드디어 내 내장이 가득찬 이 기분"));
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(OnTypeLine("음 이건 좀 어렵네"));
        yield return new WaitForSeconds(2);
        Isconsoleactive = false;
        yield return StartCoroutine(OnType("어어..."));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(OnType(" 그냥 어,,,"));
        cls();
        yield return new WaitForSeconds(1);
    }
    void Start()
    {
        Eyemove(-70, 60, false);
        StartCoroutine(Saying());
        StartCoroutine(consoletypein());
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
