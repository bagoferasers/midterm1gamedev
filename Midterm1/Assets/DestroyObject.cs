using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    public GameObject g;
    public int w;

    // Update is called once per frame
    void Update()
    {
        Destroy( g, w );
    }
}