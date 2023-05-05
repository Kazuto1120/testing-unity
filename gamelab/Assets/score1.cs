using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score1 : MonoBehaviour
{
    public int Score;
    public Text Pscore;
    private void Awake()
    {
        Score=PlayerPrefs.GetInt("Score");
        set(Score);
    }

    public void add( int x)
    {
        Score += x;
        Pscore.text = Score.ToString();
        PlayerPrefs.SetInt("Score", Score);
    }
    public void set(int x)
    {
        Score = x;
        Pscore.text = Score.ToString();
        PlayerPrefs.SetInt("Score", Score);
    }
}
