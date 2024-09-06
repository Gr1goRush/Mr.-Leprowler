
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof(Unit))]
public class UnitAutoStage : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private float _potRevealMinTime;
    private float _potRevealMaxTime;

    private float _potHideMinTime;
    private float _potHideMaxTime;

    private void OnValidate()
    {
        unit ??= GetComponent<Unit> ();
    }

    public void InizializeConfig()
    {
        //Debug.Log("Inizialize");
        _potHideMaxTime = unit.LevelConfig.PotHideMaxTime;
        _potHideMinTime = unit.LevelConfig.PotHideMinTime;
        _potRevealMaxTime = unit.LevelConfig.PotRevealMaxTime;
        _potRevealMinTime = unit.LevelConfig.PotRevealMinTime;


        StartCoroutine(UnitAutoLife());
    }

    private IEnumerator UnitAutoLife()
    {
        while (true)
        {
            if (!GameManager.IsGamePaused)
            {
                if (unit.Stage == UnitStage.GotOut)
                {
                    yield return new WaitForSeconds(Random.Range(_potHideMinTime, _potHideMaxTime));
                    unit.UpdateStage();
                }
                else
                {
                    yield return new WaitForSeconds(Random.Range(_potRevealMinTime, _potRevealMaxTime));
                    unit.UpdateStage();
                }
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
