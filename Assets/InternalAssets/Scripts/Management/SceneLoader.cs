using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenuScene()
    {
        GameScene.LoadMenu();
    }

    public void LoadGameplayScene()
    {
        GameScene.LoadGame();
    }

    public void LoadSupergameScene()
    {
        GameScene.LoadSuperGame();
    }
}
