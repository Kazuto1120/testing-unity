using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class r3 : MonoBehaviour
{
    public Text textn;
    public Text texts;
    // Start is called before the first frame update
    void Start()
    {
        textn.text = PlayerPrefs.GetString("name2");
        texts.text = PlayerPrefs.GetInt("leader2").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
