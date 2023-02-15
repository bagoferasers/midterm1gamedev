using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoodedWitchInstance : MonoBehaviour
{
    [ Header( "enter object to generate" ) ]
    public GameObject g;

    Vector3 random;
    GameObject UICanvas;

    // Start is called before the first frame update
    void Start( )
    {
        UICanvas = GameObject.Find( "UICanvas" );
        random = new Vector3( Random.Range( -13, 13 ), UICanvas.transform.position.y + 30, transform.position.z );
        generateMe( );
        
    }

    // Update is called once per frame
    void Update( )
    {
        random = new Vector3( Random.Range( -13, 13 ), UICanvas.transform.position.y + 30, transform.position.z );
    }

    void generateMe( )
    {
        StartCoroutine( gen( ) );
    }
    
    public IEnumerator gen( )
    {
        if( isAreaEmpty( UICanvas.transform.position ) )
        {
            GameObject i = Instantiate( g, random, Quaternion.identity );        
            i.transform.parent = gameObject.transform;
            yield return new WaitForSeconds( 15 );
        }
        generateMe( );
    }   

    public bool isAreaEmpty( Vector3 pos ) 
    {
        GameObject[ ] all = GameObject.FindGameObjectsWithTag( "dontSpawnHere" );
        foreach (GameObject g in all )
        {
            if( g.transform.position == pos )
                return false;
        }
        return true;
    }
}
