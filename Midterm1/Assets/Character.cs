using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [ Header( "Movement" ) ]
    public float speed;

    float playerHealth;
    float shieldHealth;
    float shieldStrength;
    public static float playerScore;
    Rigidbody2D rb2d;
    private Animator animator;

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
        playerHealth = 100f;
        shieldHealth = 6f;
        shieldStrength = 50f;
        
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

        if( playerHealth <= 0 )
        {
            StartCoroutine( dieScene( ) );
            Debug.Log( "Changed scene to Death." );
        }

        /* player direction animation */
        float directX = Input.GetAxisRaw( "Horizontal" );
        animator = GetComponent< Animator >( );

        if( directX == 0f )
        {
            //move forward
            animator.SetBool( "playerForward", true );
            animator.SetBool( "playerLeft", false ); 
            animator.SetBool( "playerRight", false ); 
        }
        else if( directX < 0f )
        {
            //move left
            animator.SetBool( "playerLeft", true );
            animator.SetBool( "playerRight", false );
            animator.SetBool( "playerForward", false );
        }
        else if( directX > 0f )
        {
            //move right
            animator.SetBool( "playerRight", true );
            animator.SetBool( "playerLeft", false ); 
            animator.SetBool( "playerForward", false );
        }
    }
    
    void FixedUpdate( )
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),0,0) * speed * Time.deltaTime;    
    }

    private void OnTriggerEnter2D( Collider2D collider )
    {
        // handle collision with heart
        if( collider.tag == "healthRegen" )
        {
            Debug.Log( "Collided with healthRegen" );
            GameObject heartGenerator = GameObject.Find( "heartGenerator" );
            heartGenerator.GetComponent< AudioSource >( ).Play( );
            if( playerHealth < 100 && ( ( playerHealth + 10 ) < 100 ) )
            {
                playerHealth += 10;
                playerScore += 10;
            }
            else if( playerHealth < 100 && ( ( playerHealth + 10 ) > 100 ) )
            {
                playerHealth = 100;
                playerScore += 10;
            }
            else
                playerScore += 10;
            Destroy( collider.gameObject );
        }

        // handle collision with moon stone shield
        if( collider.tag == "moonStoneShield" )
        {
            Debug.Log( "Collided with moonStoneShield" );
            GameObject moonGenerator = GameObject.Find( "moonStoneGenerator" );
            moonGenerator.GetComponent< AudioSource >( ).Play( );
            if( shieldHealth < shieldStrength && ( ( shieldHealth + 10 ) < shieldStrength ) )
            {
                shieldHealth += 10;
                playerScore += 10;
            }
            else if( shieldHealth < shieldStrength && ( ( shieldHealth + 10 ) > shieldStrength ) )
            {
                shieldHealth = shieldStrength;
                playerScore += 10;
            }
            else
                playerScore += 10;
            Destroy( collider.gameObject );
        }

///////////////////////////////////////////////currently here/////////////////////////////////////////////
        // handle collision with witch spinning
        if( collider.tag == "witchCollision" )
        {
            Debug.Log( "Collided with witch" );
            GameObject spinWitchGenerator = GameObject.Find( "spinWitchGenerator" );
            spinWitchGenerator.GetComponent< AudioSource >( ).Play( );

            if( shieldHealth > 0 && ( ( shieldHealth - 5 ) > 0 ) )
            {
                shieldHealth -= 5;
                playerScore -= 5;
            }
            else if( shieldHealth > 0 && ( ( shieldHealth - 5 ) <= 0 ) )
            {
                float remainder = shieldHealth - 5;
                if( playerHealth > 0 && ( ( playerHealth + remainder ) > 0 ) )
                {
                    playerHealth += remainder;
                    shieldHealth = 0;
                    playerScore -= 5;
                }
                else
                {
                    shieldHealth = 0;
                    playerHealth = 0;
                    playerScore -= 5;
                }
            }
            else if( shieldHealth == 0 && playerHealth > 0 && ( ( playerHealth - 5 ) > 0 ) )
            {
                playerHealth -= 5;
                playerScore -= 5;
            }
            else if( shieldHealth == 0 && playerHealth > 0 && ( ( playerHealth - 5 ) < 0 ) )
            {
                playerHealth = 0;
                playerScore -= 5;
            }
            else
                playerScore -= 5;
        }

///////////////////////////////////////////////currently here/////////////////////////////////////////////
        if( collider.tag == "boltCollision" )
        {
            Debug.Log( "Collided with bolt" );
            GameObject spinWitchGenerator = GameObject.Find( "spinWitchGenerator" );
            spinWitchGenerator.GetComponent< AudioSource >( ).Play( );
            if( shieldHealth > 0 && ( ( shieldHealth - 10 ) > 0 ) )
                shieldHealth -= 10;
            else if( shieldHealth > 0 )
                shieldHealth = 0;
            else if( playerHealth > 0 )
                playerHealth -= 10;
            Destroy( collider.gameObject );
        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////

        if( collider.tag == "witchHoodedCollision" )
        {
            Debug.Log( "Collided with hooded witch" );
            GameObject bossWitchGenerator = GameObject.Find( "bossWitchGenerator" );
            bossWitchGenerator.GetComponent< AudioSource >( ).Play( );
            if( shieldHealth > 0 && ( ( shieldHealth - 10 ) > 0 ) )
                shieldHealth -= 10;
            else if( shieldHealth > 0 && ( ( shieldHealth - 10 ) < 0 ) )
                shieldHealth = 0;
            else if( playerHealth > 0 )
                playerHealth -= 10;
        }

        if( collider.tag == "ENDGAMEOBJECT" )
        {
            Debug.Log( "Collided with hooded bolt." );
            GameObject bossWitchGenerator = GameObject.Find( "bossWitchGenerator" );
            bossWitchGenerator.GetComponent< AudioSource >( ).Play( );
            Destroy( collider.gameObject );
            StartCoroutine( dieScene( ) );
            Debug.Log( "Changed scene to Death." );
            
        }

        if( collider.tag == "YOUWON" )
        {
            Debug.Log( "You completed the game." );
            StartCoroutine( winScene( ) );
            Debug.Log( "Changed scene to Win." );
        }
    }

    public IEnumerator dieScene( )
    {
        SceneManager.LoadScene( "Death" );
        yield return null;
    }

    public IEnumerator winScene( )
    {
        SceneManager.LoadScene( "Win" );
        yield return null;
    }
}