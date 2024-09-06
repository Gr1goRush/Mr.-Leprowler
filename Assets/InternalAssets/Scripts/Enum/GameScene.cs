using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public static class GameScene
{
    public const string Boot = "Load";
    public const string Game = "Game";
    public const string Menu = "Menu";
    public const string Super = "SuperGame";
    public static void LoadBoot()
    {
        SceneManager.LoadScene(Boot);
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(Game);
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene(Menu);
    }

    public static void LoadMenu(int MenuWindowID)
    {
        MenuSystem.StartWindow = MenuWindowID;
        SceneManager.LoadScene(Menu);
    }

    public static void LoadSuperGame()
    {
        SceneManager.LoadScene(Super);
    }
}
