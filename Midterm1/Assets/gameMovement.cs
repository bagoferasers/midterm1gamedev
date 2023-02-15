using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMovement : MonoBehaviour
{
    Vector3 v;
    
    [ Header( "enter speed of game scroll" ) ]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( wait( ) );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate( Vector3.down * Time.deltaTime * speed, Space.World );
    }

    IEnumerator wait( )
    {
        yield return new WaitForSeconds( 4 );
    }
}
