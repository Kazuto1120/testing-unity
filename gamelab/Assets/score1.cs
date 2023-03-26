using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score1 : MonoBehaviour
{
    public int Score;
    public Text Pscore;

    public void add( int x)
    {
        Score += x;
        Pscore.text = Score.ToString();
    }
}
