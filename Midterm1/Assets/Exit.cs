using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void exitGame( )
    {
        StartCoroutine( goodbye( ) );
    }
    
    public IEnumerator goodbye( )
    {
        FadeMeOut( );
        yield return new WaitForSeconds( 2 );
        Debug.Log( "exitgame" );
        Application.Quit( );
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