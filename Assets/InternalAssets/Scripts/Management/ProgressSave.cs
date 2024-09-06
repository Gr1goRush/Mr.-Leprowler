using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProgressSave
{
    public static void CompleteLevel(string LevelName, int StarsCount)
    {
        PlayerPrefs.SetInt(FormattToLevelComplete(LevelName), 1);

        if (PlayerPrefs.GetInt(FormattToLevelStars(LevelName)) < StarsCount)
        {
            PlayerPrefs.SetInt(FormattToLevelStars(LevelName), StarsCount);
        }

    }

    public static bool LevelIsCompleted(string LevelName, out int StarsCount)
    {
        StarsCount = PlayerPrefs.GetInt(FormattToLevelStars(LevelName));
        return PlayerPrefs.GetInt(FormattToLevelComplete(LevelName)) == 1;
    }

    public static string FormattToLevelComplete(string LevelName)
    {
        return $"IsComplete{LevelName}";
    }

    public static string FormattToLevelStars(string LevelName)
    {
        return $"StarRate{LevelName}";
    }

    public static int CompletedLevelsCount()
    {
        return PlayerPrefs.GetInt("CompletedLevels");
    }
    public static void OpenNewLevel()
    {
        int tmp = PlayerPrefs.GetInt("CompletedLevels");
        tmp++;
        PlayerPrefs.SetInt("CompletedLevels", tmp);
    }
}
