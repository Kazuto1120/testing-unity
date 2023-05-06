using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highscore : MonoBehaviour
{
    [SerializeField] int entree = 5;
    [SerializeField] int currentscore = 0;
    [SerializeField] string currentname = "name";
    [SerializeField] GameObject enter;

    private void Awake()
    {
        currentscore = PlayerPrefs.GetInt("Score");
        currentname = PlayerPrefs.GetString("playername");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < entree; i++)
        {
            string tempn = "name" + i;
            string temp = "leader" + i;
            if (currentscore > PlayerPrefs.GetInt(temp)) {
                int t = PlayerPrefs.GetInt(temp);
                string n = PlayerPrefs.GetString(tempn);
                PlayerPrefs.SetInt(temp,currentscore);
                PlayerPrefs.SetString(tempn, currentname);
                currentscore = t;
                currentname = n;
            }
        }
        

        
    }

   
}
