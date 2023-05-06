using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text textt;

    [SerializeField] float timeRemaining=10f; 

    void Update()
    {
        
        timeRemaining -= Time.deltaTime;

        textt.text = timeRemaining.ToString();

        // Check if the timer has run out
        if (timeRemaining <= 0f)
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
