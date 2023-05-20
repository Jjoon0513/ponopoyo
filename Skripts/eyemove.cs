using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyemove : MonoBehaviour
{
    public uint div = 10;
    public GameObject Eyes;
    void Update()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = mousePosition / div;
        mousePosition.z = -3f;
        Eyes.transform.position = mousePosition;
    }
}
