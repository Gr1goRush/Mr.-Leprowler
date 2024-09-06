using System.IO;
using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
public class Cheats : EditorWindow
{
    private int intValue;

    [Header("MenuSystemHelperFields")]
    private MenuSystem menuSystem;

    [MenuItem("Window/Cheats Window")]
    public static void ShowWindow()
    {
        GetWindow<Cheats>("Cheats");
    }

    private void OnGUI()
    {
        GUILayout.Label("Save helper");

        intValue = EditorGUILayout.IntField("Enter money count:", intValue);

        if (GUILayout.Button("Set Variable"))
        {
            PlayerBalance.SetMoney(EditorGUILayout.IntField("New Balance:", intValue));
            Debug.Log(PlayerBalance.PlayerMoney);
        }

        if (GUILayout.Button("Clear Save"))
        {
            PlayerPrefs.DeleteAll();
        }

        GUILayout.Label(" ");

        // SCENES HELPER
        GUILayout.Label("Scenes helper");

        string scenesFolderPath = $@"{Application.dataPath}/InternalAssets/Scenes";
        foreach (string filePath in Directory.GetFiles(scenesFolderPath, "*.unity"))
        {
            string fileName = Path.GetFileName(filePath);

            if (GUILayout.Button($"Open {fileName} scene"))
            {
                EditorSceneManager.OpenScene(filePath);
            }

        }
        //

        GUILayout.Label(" ");
        //MENU HELPER
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            menuSystem ??= FindObjectOfType<MenuSystem>();
            GUILayout.Label("Menu helper");

            for (int i = 0; i < menuSystem.WindowsArray.Length; i++)
            {
                if (GUILayout.Button($"Open {menuSystem.WindowsArray[i].name}"))
                {
                    menuSystem.DebugOpenWindow(i);
                }
            }

            GUILayout.Label(" ");
        }
        else
        {
            menuSystem = null;
        }

        //
    }

    private string FormattToPath(string fileName)
    {
        return $@"{Application.dataPath}/InternalAssets/Scenes/{fileName}.unity";
    }
}

#endif
