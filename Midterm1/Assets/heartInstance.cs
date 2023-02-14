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
        random = new Vector3( Random.Range( -10, 10 ), UICanvas.transform.position.y + 10, 0 );
        generateMe( );
        
    }

    // Update is called once per frame
    void Update( )
    {
        random = new Vector3( Random.Range( -10, 10 ), UICanvas.transform.position.y + 10, 0 );
        p = int.Parse( playerHealth.text );
        generateMe( );
    }

    void generateMe( )
    {
        if( p > 0 )
        {
            StartCoroutine( Wait( ) );
            GameObject heart = Instantiate( g, random, Quaternion.identity );        
            heart.transform.parent = gameObject.transform;
            p = int.Parse( playerHealth.text );
        }
    }
    
    public IEnumerator Wait( )
    {
        yield return new WaitForSeconds( 10 * Time.deltaTime );
    }

}
