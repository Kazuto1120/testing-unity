using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class r5 : MonoBehaviour
{
    public Text textn;
    public Text texts;
    // Start is called before the first frame update
    void Start()
    {
        textn.text = PlayerPrefs.GetString("name4");
        texts.text = PlayerPrefs.GetInt("leader4").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
