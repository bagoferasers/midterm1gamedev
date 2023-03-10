using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltGen : MonoBehaviour
{
    [ Header( "enter object to generate" ) ]
    public GameObject g;

    [ Header( "enter object to start at" ) ]
    public GameObject s;

    // Start is called before the first frame update
    void Start( )
    {
        Vector3 newV = new Vector3( s.transform.position.x, s.transform.position.y, s.transform.position.z );
        GameObject i = Instantiate( g, newV, Quaternion.identity );
        i.transform.parent = gameObject.transform;
        i.transform.rotation = Quaternion.Euler( new Vector3( 0f, 0f, 270f ) );
        i.transform.localScale = new Vector3( 2, 2, 1 );
        generateMe( );
    }

    void generateMe( )
    {
        StartCoroutine( gen( ) );
    }
    
    public IEnumerator gen( )
    {
        yield return new WaitForSeconds( 4 );
        Vector3 newV = new Vector3( s.transform.position.x, s.transform.position.y, s.transform.position.z );
        GameObject i = Instantiate( g, newV, Quaternion.identity );
        i.transform.parent = gameObject.transform;
        i.transform.rotation = Quaternion.Euler( new Vector3( 0f, 0f, 270f ) );
        i.transform.localScale = new Vector3( 2, 2, 1 );
        generateMe( );
    }
}
