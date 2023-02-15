using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;
    public static bool hasStarted = false;
    /////////////////////////////////////////////////////////////////
    public void goToScene( )
    {
        hasStarted = true;
        StartCoroutine( ChangeScene( ) );
        Debug.Log( "Changed scene." );
    }

    public IEnumerator ChangeScene( )
    {
        FadeMeOut( );
        yield return new WaitForSeconds( 2 );
        SceneManager.LoadScene( scene );
    }
///////////////////////////////////////////////////////////////////////
    public void goToNextSceneInSequence( )
    {
        StartCoroutine( goToNextSceneInSequenceNumerator( ) );
        Debug.Log( "Changed scene." );
    }

    public IEnumerator goToNextSceneInSequenceNumerator( )
    {
        yield return new WaitForSeconds( 5 );
        FadeMeOut( );
        SceneManager.LoadScene( scene );
    }
//////////////////////////////////////////////////////////////////////////////
    public void FadeMeOut( )
    {
        StartCoroutine ( FadeOut( ) );
    }

    /* Fades scene to black by decrementing alpha over time. */
    IEnumerator FadeOut( )
    {
        CanvasGroup canvasGroup = GetComponent< CanvasGroup >( );

        while( canvasGroup.alpha < 1 )
        {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }

        /* This makes sure buttons aren't interactable while fading out. */
        canvasGroup.interactable = false;
        yield return null;
    }
///////////////////////////////////////////////////////////////
    public void Start( )
    {
        if( hasStarted == true )
            goToNextSceneInSequence( );
        else if( string.Compare( scene, "Game" ) == 0 )  
            goToScene( );
    }
}