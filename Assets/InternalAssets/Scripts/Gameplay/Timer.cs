using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTimerEnd;
    private int RemainTime;
    private int chachedTime;
    public static bool HalfTimerRemain = false;

    [SerializeField] private Text _timerText;

    private void OnEnable() => GameManager.OnLevelConfigLoaded += InizializeConfig;
    private void OnDisable() => GameManager.OnLevelConfigLoaded -= InizializeConfig;

    public void InizializeConfig(LevelConfig config)
    {
        RemainTime = config.GameTime;
        chachedTime = RemainTime;
        StartCoroutine(StartTimer() );
    }

    public IEnumerator StartTimer()
    {
        while (RemainTime > 0)
        {
            if (!GameManager.IsGamePaused)
            {


                TimeSpan time = TimeSpan.FromSeconds(RemainTime);
                string formattedTime = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
                _timerText.text = formattedTime;
                RemainTime -= 1;
                if (RemainTime < chachedTime / 2)
                {
                    HalfTimerRemain = true;
                }

                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return null;
            }
        }
        OnTimerEnd?.Invoke();
    }
}
