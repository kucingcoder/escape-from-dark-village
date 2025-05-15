using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
