using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level-1", LoadSceneMode.Single);
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level-2", LoadSceneMode.Single);
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level-3", LoadSceneMode.Single);
    }
}
