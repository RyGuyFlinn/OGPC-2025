using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditText : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(scroll());
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator scroll()
    {
        yield return new WaitForSeconds(35f);

        Quit();
    }
}
