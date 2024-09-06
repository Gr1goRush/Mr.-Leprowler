using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static event Action<LevelConfig> OnLevelConfigLoaded;
    public UnityEvent OnSupergameCharge;
    public static bool IsGamePaused { get; private set; } = false;

    public LevelConfig _defaultLevelConfig;
    public static LevelConfig LevelConfig { get; private set; }


    [Header("StarsArray")]
    [SerializeField] private Star[] starsArray;

    private int _currentLevelKnocked;
    private int _configKnocedRequest;
    private string _configLevelName;

    private int starsCount = 1;
    public UnityEvent OnGameWin;

    [Header("Economy")]
    [SerializeField] private Text _rewardText;
    private int Reward;

    private void OnEnable()
    {
        Unit.OnUnitKnockedOut += ApplyKnockedDown;
        Unit.OnSuperGameCharge += StartSuperGame;
    }

    private void OnDisable()
    {
        Unit.OnUnitKnockedOut -= ApplyKnockedDown;
        Unit.OnSuperGameCharge -= StartSuperGame;
    }

    private void Start()
    {
        IsGamePaused = false;
        LevelConfig ??= _defaultLevelConfig;
        _configKnocedRequest = LevelConfig.KnockedOutRequest;
        _configLevelName = LevelConfig.LevelName;
        OnLevelConfigLoaded?.Invoke(LevelConfig);
        UnitsController.RedUnitSpawnedAlready = false;
    }

    public static void SetLevelConfig(LevelConfig newConfig)
    {
        LevelConfig = newConfig;
    }

    public void SetGamePause(bool state)
    {
        IsGamePaused = state;
        Debug.Log("PAUSE STATE = " + IsGamePaused);
    }

    public void ApplyKnockedDown()
    {
        Reward += LevelConfig.KnockReward;
        _currentLevelKnocked++;
        CheckForWin();
    }

    public void CheckForWin()
    {
        if (_currentLevelKnocked >= _configKnocedRequest)
        {
            if (!ProgressSave.LevelIsCompleted(LevelConfig.LevelName, out int starscount))
            {
                ProgressSave.OpenNewLevel();
            }

            OnGameWin?.Invoke();

            if (!Timer.HalfTimerRemain) starsCount++;
            if (!Unit.SomebodyEscaped) starsCount++;

            ProgressSave.CompleteLevel(_configLevelName, starsCount);
            Debug.Log("levelname = " + _configLevelName + " stars= " + starsCount);
            for (int i = 0; i < starsCount; i++)
            {
                starsArray[i].Activate();
            }

            _rewardText.text = $"{Reward * starsCount} X{starsCount}";
            PlayerBalance.AddMoney(Reward * starsCount);

            
        }
    }

    public void StartSuperGame()
    {
        OnSupergameCharge.Invoke();
    }
}
