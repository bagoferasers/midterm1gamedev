using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartInstance : MonoBehaviour
{
    [ Header( "enter object to generate" ) ]
    public GameObject g;

    [ Header( "enter player health to monitor" ) ]
    public Text playerHealth;

    GameObject UICanvas;
    Vector3 random;
    int p = 0;
    // Start is called before the first frame update
    void Start( )
    {
        UICanvas = GameObject.Find( "UICanvas" );
        p = int.Parse( playerHealth.text );
        random = new Vector3( Random.Range( -10, 10 ), UICanvas.transform.position.y + 10, 0 );
        GameObject heart = Instantiate( g, random, Quaternion.identity );
        heart.transform.parent = gameObject.transform;
        generateMe( );
        
    }

    // Update is called once per frame
    void Update( )
    {
        random = new Vector3( Random.Range( -10, 10 ), UICanvas.transform.position.y + 10, 0 );
        p = int.Parse( playerHealth.text );
    }

    void generateMe( )
    {
        StartCoroutine( gen( ) );
    }
    
    public IEnumerator gen( )
    {
        yield return new WaitForSeconds( 8 );
        if( p > 0 )
        {
            GameObject heart = Instantiate( g, random, Quaternion.identity );        
            heart.transform.parent = gameObject.transform;
            generateMe( );
        }
    }   

}
