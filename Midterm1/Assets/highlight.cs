using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight : MonoBehaviour
{
    public void setHighlighted( )
    {
        SpriteRenderer b = GetComponent< SpriteRenderer >( );
        b.color = Color.white;
    }

    public void setUnHighlighted( )
    {
        SpriteRenderer b = GetComponent< SpriteRenderer >( );
        b.color = Color.black;
    }
}
