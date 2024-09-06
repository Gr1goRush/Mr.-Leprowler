using System.Collections.Generic;
using UnityEngine;

public class UnitsController : MonoBehaviour
{
    private int UnitsCount;
    public static bool RedUnitSpawnedAlready = false;

    [SerializeField] private Transform[] _rootTransformsArray;
    [SerializeField] private Unit _unitPrefab;

    private int _rootSpawnerIndex;

    private List<Unit> _unitList = new List<Unit>();

    private void OnEnable() => GameManager.OnLevelConfigLoaded += InizializeConfig;
    private void OnDisable() => GameManager.OnLevelConfigLoaded -= InizializeConfig;

    public void InizializeConfig(LevelConfig config)
    {
        UnitsCount = config.PotsCount;

        for (int i = 0; i < UnitsCount; i++)
        {
            Unit newUnit = (Instantiate(_unitPrefab, _rootTransformsArray[_rootSpawnerIndex]));
            _unitList.Add(newUnit);
            newUnit.SetConfig(config);

            if (i == 1) { _rootSpawnerIndex = 1; }
            else if (i == 4) { _rootSpawnerIndex = 2; }
            else if (i == 6) { _rootSpawnerIndex = 0; }
            else if (i == 7) { _rootSpawnerIndex = 2; }

            

           // else if (i == 8) { _rootSpawnerIndex = 2; }
        }

        int RandomIndex = Random.Range(0, UnitsCount);
        int iterator = 0;
        foreach (Unit unit in _unitList)
        {
            if (iterator == RandomIndex)
            {
                unit.SetUnitAsRed();
                RedUnitSpawnedAlready = true;
            }
            iterator++;
        }
    }


}
