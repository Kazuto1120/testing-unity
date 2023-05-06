using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input : MonoBehaviour
{
    public InputField Pname;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("playername", Pname.text);
    }
}
