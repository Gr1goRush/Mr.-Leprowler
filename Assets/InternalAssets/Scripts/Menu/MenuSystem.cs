using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuSystem : MonoBehaviour
{
    public static int StartWindow = 0;

    public UnityEvent OnNewWindowSelected;
    [SerializeField] private GameObject[] _windows;
    public GameObject[] WindowsArray => _windows;

    private void Start()
    {
        DebugOpenWindow(StartWindow);
        StartWindow = 0;
    }

    public void OpenWindow(int menuWindow)
    {
        StartCoroutine(OpenWindowSleep(menuWindow));
    }

    public IEnumerator OpenWindowSleep(int menuWindow)
    {
        OnNewWindowSelected?.Invoke();
        yield return new WaitForSeconds(0.5f);
        foreach (var w in _windows)
        {
            w.SetActive(false);
        }

        _windows[(menuWindow)].SetActive(true);
    }

    public void DebugOpenWindow(int menuWindow)
    {
        foreach (var w in _windows)
        {
            w.SetActive(false);
        }

        _windows[(menuWindow)].SetActive(true);
    }

    [ContextMenu("Clear")]
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
    }

    [ContextMenu("PrintPath")]
    public void GetPatch()
    {
        Debug.Log(Application.dataPath);
    }
}

