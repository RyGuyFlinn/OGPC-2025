using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName;
    public GameObject settingsMenu;
    public GameObject[] mainMenu;

    public void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void Settings()
    {
        for (int i = 0; i < mainMenu.Length; i++)
        {
            mainMenu[i].gameObject.SetActive(!mainMenu[i].gameObject.active);
        }
        settingsMenu.SetActive(!settingsMenu.active);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
