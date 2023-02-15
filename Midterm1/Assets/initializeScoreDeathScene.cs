using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class initializeScoreDeathScene : MonoBehaviour
{
    [ Header( "enter player score data here" ) ]
    public Text s;

    void Start()
    {
        s.text = "" + Character.playerScore;
        StartCoroutine( goToMain( ) );
        Debug.Log( "Changed scene to Main." );
    }

    public IEnumerator goToMain( )
    {
        yield return new WaitForSeconds( 4 );
        SceneManager.LoadScene( "MainMenu" );
    }
}
