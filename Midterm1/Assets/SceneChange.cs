using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void goToGame( )
    {
        StartCoroutine( ChangeScene( ) );
        Debug.Log( "Changed scene to Game." );
    }

    public IEnumerator ChangeScene( )
    {
        FadeMeOut( );
        yield return new WaitForSeconds( 2 );
        SceneManager.LoadScene( "Game" );
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
}
