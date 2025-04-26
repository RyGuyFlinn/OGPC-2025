using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;
    public GameObject settingsMenu;

    bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controlPause();
        }
    }

    public void controlPause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }

    public void settings()
    {
        pauseMenu.SetActive(!pauseMenu.active);
        settingsMenu.SetActive(!settingsMenu.active);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
