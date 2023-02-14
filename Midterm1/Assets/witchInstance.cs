using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchInstance : MonoBehaviour
{
    [ Header( "enter object to generate" ) ]
    public GameObject g;

    Vector3 random;
    GameObject UICanvas;

    // Start is called before the first frame update
    void Start( )
    {
        UICanvas = GameObject.Find( "UICanvas" );
        random = new Vector3( Random.Range( -10, 10 ), UICanvas.transform.position.y + 30, 0 );
        GameObject i = Instantiate( g, random, Quaternion.identity );
        i.transform.parent = gameObject.transform;
        generateMe( );
        
    }

    // Update is called once per frame
    void Update( )
    {
        random = new Vector3( Random.Range( -10, 10 ), UICanvas.transform.position.y + 30, 0 );
    }

    void generateMe( )
    {
        StartCoroutine( gen( ) );
    }
    
    public IEnumerator gen( )
    {
        yield return new WaitForSeconds( 8 );
        GameObject i = Instantiate( g, random, Quaternion.identity );        
        i.transform.parent = gameObject.transform;
        generateMe( );
    }   


}
