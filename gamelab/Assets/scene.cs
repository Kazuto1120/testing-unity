using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scene : MonoBehaviour
{
    public static bool Pause = false;
    [SerializeField] GameObject logic;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.GetComponent<score1>().Score >= 10) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause) {
                resume();
            }
            else {
                pause();
            }
        } }
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Pause = false;
    }
    void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Pause = true;
    }
    public void startMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("start");
    }
}
