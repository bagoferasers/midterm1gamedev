using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [ Header( "Movement" ) ]
    public float speed;

    float playerHealth;
    Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start( )
    {
        rb2d = GetComponent< Rigidbody2D >( );
        playerHealth = 50f;
    }

    // Update is called once per frame
    void Update( )
    {
        
    }
    
    void FixedUpdate( )
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),0,0) * speed * Time.deltaTime;    
    }

    private void OnTriggerEnter2D( Collider2D collider )
    {
        if( collider.tag == "healthRegen" && playerHealth < 100 )
        {
            Destroy( collider.gameObject );
            Debug.Log( "Collided with healthRegen" );
            playerHealth += 10;
        }
    }
}
