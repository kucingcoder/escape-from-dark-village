using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void pause()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync("Pause");
    }
    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
