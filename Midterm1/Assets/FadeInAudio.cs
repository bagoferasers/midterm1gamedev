using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAudio : MonoBehaviour
{
    public float fadeTime;
    // Start is called before the first frame update
    void Start()
    {
        fadeInMusic( );
    }

    IEnumerator fadeInMusic( )
    {
        AudioSource audioSource = GetComponent< AudioSource >( );
        float maxVol = audioSource.volume;
        float t = 0;
        audioSource.volume = 0;
        audioSource.Play( );
        while( t < fadeTime )
        {
            t += Time.deltaTime;
            yield return null;
            audioSource.volume = Mathf.Lerp( 0, maxVol, t / fadeTime );
        }
        audioSource.volume = maxVol;
        yield return null;
    }
}
