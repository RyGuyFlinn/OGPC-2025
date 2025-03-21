using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WishList : MonoBehaviour
{
    public string gameSceneName;

    public void Quit()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
