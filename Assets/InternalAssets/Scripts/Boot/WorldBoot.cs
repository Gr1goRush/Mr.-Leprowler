using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class WorldBoot : MonoBehaviour
{
    [SerializeField] private bool _loadingFakeTimeEnabled;
    [SerializeField, Range(0, 10)] private int _loadingFakeTime;

    
    [SerializeField] private Text _loadPercentTest;
    [SerializeField] private WaitForSeconds _sleepTime = new WaitForSeconds(1);

    private const int hundredPercent = 100;

    public void Start()
    {
        //FastBoot();
        StartCoroutine(Loading(_loadingFakeTimeEnabled));
 
    }

    private IEnumerator Loading(bool EnableFakeLoadingTime)
    {
        if (_loadingFakeTimeEnabled)
        {
            for (int i = _loadingFakeTime; i > 0; i--)
            {
                _loadPercentTest.text = $"{hundredPercent / i}%";
                yield return _sleepTime;
            }
        }

        GameScene.LoadMenu();
    }

    private void FastBoot()
    {
        //PlayerBalance.LoadBalance();
    }
}
