using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class play : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("health", 3);
    }
    public void Play()
    {
        SceneManager.LoadScene("scene 1");
    }

}
