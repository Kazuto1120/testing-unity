using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ranking : MonoBehaviour
{
    public Text textn;
    public Text texts;
    private int rankingnum = 0;
    // Start is called before the first frame update
    void Start()
    {
        string name = "name" + rankingnum;
        string num = "leader" + rankingnum;
        rankingnum = PlayerPrefs.GetInt("rank");
        PlayerPrefs.SetInt("rank",rankingnum+1);
        textn.text = PlayerPrefs.GetString(name);
        texts.text = PlayerPrefs.GetInt(num).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
