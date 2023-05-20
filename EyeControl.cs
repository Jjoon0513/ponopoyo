using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeControl : MonoBehaviour
{
    GameObject Eyebrows1;
    GameObject EyeCover;

    IEnumerator Sleep(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
    }
    void FixedUpdate()
    {
        float rand = Random.Range(2.0f, 4.0f);

    }

}
