using UnityEngine;
using UnityEngine.SceneManagement;

public static class ReloadScene
{
    public static void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    
    public static void LoadLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
