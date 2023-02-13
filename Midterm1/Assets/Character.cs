using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [ Header( "Movement" ) ]
    public float speed;
    Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start( )
    {
        rb2d = GetComponent< Rigidbody2D >( );
    }

    // Update is called once per frame
    void Update( )
    {
        
    }
    
    void FixedUpdate( )
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),0,0) * speed * Time.deltaTime;    
    }
}
