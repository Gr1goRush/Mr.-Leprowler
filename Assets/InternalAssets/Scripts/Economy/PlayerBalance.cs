using System;
using UnityEngine;
public static class PlayerBalance
{
    public static event Action<int> OnBalanceChange;
    private static int _playerMoney;
    public static int PlayerMoney => _playerMoney;
    public static int ChachedMoney => PlayerPrefs.GetInt("Balance");
    public static void AddMoney(int value)
    {
        LoadBalance();
        _playerMoney += value;
        SaveBalance();
        OnBalanceChange?.Invoke(ChachedMoney);
    }

    public static void RemoveMoney(int value)
    {
        LoadBalance();
        _playerMoney -= value;
        SaveBalance();
        OnBalanceChange?.Invoke(ChachedMoney);
    }

    public static bool TryPurchase(int Cost)
    {
        LoadBalance();
        bool result = _playerMoney >= Cost;
        if (result) RemoveMoney(Cost);
        return result;
    }

    public static void SetMoney(int value) 
    {
        _playerMoney = value;
        SaveBalance();
        OnBalanceChange?.Invoke(ChachedMoney);
    }

    public static void SaveBalance()
    {
        PlayerPrefs.SetInt("Balance", _playerMoney);
    }

    public static void LoadBalance()
    {
        _playerMoney = PlayerPrefs.GetInt("Balance");
        OnBalanceChange?.Invoke(_playerMoney);
    }
}
