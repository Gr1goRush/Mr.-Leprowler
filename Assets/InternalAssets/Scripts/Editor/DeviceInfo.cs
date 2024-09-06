#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeviceInfo : EditorWindow
{
    [MenuItem("Window/DeviceInfoWindow")]
    public static void ShowWindow()
    {
        GetWindow<DeviceInfo>("DeviceInfo");
    }

    private void OnGUI()
    {
        UpdateView();
    }

    public void UpdateView()
    {
        GUILayout.Label($"DEVICE STATS \n");
        GUILayout.Label($"Device platform = {Application.platform}");
        GUILayout.Label($"Is mobile device = {Application.isMobilePlatform}");

        Space();

        GUILayout.Label($"SCREEN STATS \n");
        GUILayout.Label($"Screen width = {Screen.currentResolution.width}");
        GUILayout.Label($"Screen height = {Screen.currentResolution.height}");
        GUILayout.Label($"Screen resolution = {Screen.currentResolution}");
    }

    public void Space()
    {
        GUILayout.Label($"\n");
    }
}
#endif