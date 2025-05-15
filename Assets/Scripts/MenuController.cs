using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Fungsi untuk menavigasi ke scene 'Level'
    public void Play()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}