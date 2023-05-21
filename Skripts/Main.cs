using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Main : MonoBehaviour
{
    bool IsSaying;
    bool IsFocus;
    public TextMeshProUGUI Texttarget;
    public GameObject mouthop;
    public GameObject mouthcl;
    public GameObject mouthFoc;

    IEnumerator OnType(float interval, string Say, bool isfocus)
    {
        IsSaying = true;
        if (isfocus)
        {
            IsFocus = true;
        }
        foreach (char item in Say)
        {
            Texttarget.text += item;
            yield return new WaitForSeconds(interval);
        }
        IsFocus = false;
        IsSaying = false;
    }

    IEnumerator Maintext()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(OnType(0.1f, "오 드디어 내 속이 가득찬 이 기분", true));

    }
    void Start()
    {
        StartCoroutine(Saying());
        StartCoroutine(Maintext());
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
                        yield return new WaitForSeconds(1f);
                        mouthFoc.SetActive(true);
                        mouthcl.SetActive(false);
                        yield return new WaitForSeconds(1f);
                    }
                }
                else
                {
                    while (IsSaying)
                    {
                        mouthop.SetActive(false);
                        mouthcl.SetActive(true);
                        yield return new WaitForSeconds(1f);
                        mouthop.SetActive(true);
                        mouthcl.SetActive(false);
                        yield return new WaitForSeconds(1f);
                    }
                }

                mouthop.SetActive(true);
                mouthFoc.SetActive(false);
                mouthcl.SetActive(false);
            }

            yield return null;
        }
    }

}
