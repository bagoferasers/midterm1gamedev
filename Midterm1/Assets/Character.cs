using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [ Header( "Movement" ) ]
    public float speed;

    float playerHealth;
    float shieldHealth;
    float shieldStrength;
    float playerScore;
    Rigidbody2D rb2d;

    [ Header( "enter user health data here" ) ]
    public Text h;

    [ Header( "enter shield health data here" ) ]
    public Text s;
    
    [ Header( "enter shield strength data here" ) ]
    public Text ss;

    [ Header( "enter player score data here" ) ]
    public Text ps;

    // Start is called before the first frame update
    void Start( )
    {
        rb2d = GetComponent< Rigidbody2D >( );
        playerHealth = 50f;
        shieldHealth = 10f;
        shieldStrength = 20f;
        
        //figure out how to store previous scores
        playerScore = 0f;
    }

    // Update is called once per frame
    void Update( )
    {
        h.text = "" + playerHealth;
        s.text = "" + shieldHealth;
        ss.text = "" + shieldStrength;
        ps.text = "" + playerScore;
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
            playerScore += 1;
            Debug.Log( playerHealth );
        }
    }
}