using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolttranslate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent< AudioSource>( ).Play( );
    }

    // Update is called once per frame
    void Update( )
    {
        transform.Translate( new Vector3( 0, -1, 0 ) * Time.deltaTime * 5, Space.World );
    }
}
