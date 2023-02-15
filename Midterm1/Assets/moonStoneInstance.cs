using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonStoneInstance : MonoBehaviour
{
    [ Header( "enter object to generate" ) ]
    public GameObject g;

    Vector3 random;
    GameObject UICanvas;

    // Start is called before the first frame update
    void Start( )
    {
        UICanvas = GameObject.Find( "UICanvas" );
        random = new Vector3( Random.Range( -15, 15 ), UICanvas.transform.position.y + 20, 0 );
        generateStone( );
    }

    // Update is called once per frame
    void Update( )
    {
        random = new Vector3( Random.Range( -15, 15 ), UICanvas.transform.position.y + 20, 0 );
    }

    void generateStone( )
    {
        StartCoroutine( generateMoonStone( ) );
    }
    
    public IEnumerator generateMoonStone( )
    {
        yield return new WaitForSeconds( 10 );
        GameObject i = Instantiate( g, random, Quaternion.identity );        
        i.transform.parent = gameObject.transform;
        generateStone( );
    }   
}
