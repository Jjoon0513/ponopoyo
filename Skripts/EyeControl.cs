using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeControl : MonoBehaviour
{
    public GameObject EyeBrows;
    public GameObject EyeCover;
    public GameObject Eyes;
    IEnumerator Main()
    {
        while (true)
        {
            float Seconds = Random.Range(2.0f, 4.0f);
            Eyeopen(false);
            yield return new WaitForSecondsRealtime(0.1f);
            Eyeopen(true);
            yield return new WaitForSecondsRealtime(Seconds);
        }
    }

    void Eyeopen(bool iseyesopen)
    {
        if (iseyesopen == true)
        {
            EyeCover.SetActive(true);
            EyeBrows.SetActive(false);
            Eyes.SetActive(true);
        }
        else
        {
            EyeCover.SetActive(false);
            EyeBrows.SetActive(true);
            Eyes.SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(Main());
    }
}
