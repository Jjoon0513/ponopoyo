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
        Cls();
        IsSaying = true;
        foreach (char item in Say)
        {
            Texttarget.text += item;
            yield return new WaitForSeconds(interval);
        }
        IsSaying = false;
        yield return new WaitForSeconds(1f);
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
    IEnumerator ConsoleOnType(string Say, bool isclear = false)
    {
        if (isclear) consoletext.text = "C:/ponopoyo.p>>> ";
        foreach (char item in Say)
        {
            consoletext.text += item;
            yield return new WaitForSeconds(interval);
        }
        Consolecls();
    }

    void Consolecls()
    {
        consoletext.text = "C:/ponopoyo.p>>> ";
    }
    void Cls()
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
    public string Ambassador(uint group, uint num)
    {
        if (group == 1)
        {
            switch (num)
            {
                case 1:
                    return " start main texts";
                case 2:
                    return " set ponopoyo.p = {GetReturnposComset}comp. <132059161928739587192837>";
            }
        }
        else if (group == 2)
        {
            switch (num)
            {
                case 1:
                    return "오 드디어 내 내장이 가득찬 이 기분";
                case 2:
                    return "음 이건 좀 어렵네";
                case 3:
                    return "어어...";
                case 4:
                    return "그냥 어...";
            }
        }
        return null;
    }
    IEnumerator Maintext()
    {
        IsFocus = true;
        yield return new WaitForSeconds(3);
        yield return StartCoroutine(OnTypeLine(Ambassador(2, 1)));
        
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(OnTypeLine(Ambassador(2, 2)));
        yield return new WaitForSeconds(2);
        Isconsoleactive = false;
        Eyemove();
        yield return new WaitForSeconds(2);
        StartCoroutine(OnTypeLine(Ambassador(2, 3)));
        yield return new WaitForSeconds(1);
        Eyemove("Left");
        yield return new WaitForSeconds(1);
        Eyemove("Right");
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(OnType(Ambassador(2, 4)));
        yield return new WaitForSeconds(1);
        Eyemove();
    }
    public void Eyemove(string position = "Front")
    {
        switch (position)
        {
            case "Diagonal Left Up":
                eyes.transform.position = new Vector3(-70, 60, -3);
                break;
            case "Up":
                eyes.transform.position = new Vector3(0, 30, -3);
                break;
            case "Diagonal Right Up":
                eyes.transform.position = new Vector3(60, 10, -3);
                break;
            case "Front":
                eyes.transform.position = new Vector3(0, 0, -3);
                break;
            case "Diagonal Right Down":
                eyes.transform.position = new Vector3(-70, 60, -3);
                break;
            case "Down":
                eyes.transform.position = new Vector3(-10, -70, -3);
                break;
            case "Diagonal Left Down":
                eyes.transform.position = new Vector3(70, -60, -3);
                break;
            case "Left":
                eyes.transform.position = new Vector3(-90, 20, -3);
                break;
            case "Right":
                eyes.transform.position = new Vector3(90, -20, -3);
                break;
        }
    }
    IEnumerator Consoletypein()
    {
        yield return StartCoroutine(ConsoleOnType(Ambassador(1, 1)));
        yield return new WaitForSeconds(4);
        yield return StartCoroutine(ConsoleOnType(Ambassador(1, 2)));
        yield return new WaitForSeconds(4);
    }


    void Start()
    {
        Eyemove("Diagonal Left Up");
        StartCoroutine(Saying());
        StartCoroutine(Consoletypein());
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
