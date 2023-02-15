using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;
    
    public void goToScene( )
    {
        StartCoroutine( ChangeScene( ) );
        Debug.Log( "Changed scene." );
    }

    public IEnumerator ChangeScene( )
    {
        FadeMeOut( );
        if( string.Compare( scene, "HowToWin" ) == 0 )
            yield return new WaitForSeconds( 2 );
        else
            yield return new WaitForSeconds( 4 );
        SceneManager.LoadScene( scene );
    }

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

    public void Start( )
    {
        if( string.Compare( scene, "MainMenu" ) != 0 && string.Compare( scene, "Game" ) != 0
        && string.Compare( scene, "Death" ) != 0 && string.Compare( scene, "Win" ) != 0 
        && string.Compare( scene, "HowToWin" ) != 0 )
        {
            goToNextSceneInSequence( );
            Debug.Log( "Changed scene." );
        }
    }
}