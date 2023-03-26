using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public int Score;
    public Text Pscore;

    public void add() {
        Score += 1;
        Pscore.text = Score.ToString();
    }
}
