using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelConfig", menuName = "GameData/Levels")]
public class LevelConfig : ScriptableObject
{
    public string LevelName;

    private void OnValidate()
    {
        if (PotRevealMaxTime < PotRevealMinTime) PotRevealMaxTime = PotRevealMinTime;
        if (PotHideMaxTime < PotHideMinTime) PotHideMaxTime = PotHideMinTime; 
    }

    [Space(20f)]
    [Tooltip("Кол-во котелков с леприконами")]
    [Range(1, 9)] public int PotsCount;
    [Tooltip("Игровое время, по истечению таймера \n следует проигрыш")]
    public int GameTime;

    [Space(20f)]
    [Tooltip("Минимальное время, за которое гном может вылезти из котла")]
    public float PotRevealMinTime;
    [Tooltip("Максимальное время, за которое гном может вылезти из котла")]
    public float PotRevealMaxTime;

    [Space(20f)]
    [Tooltip("Минимальное время, за которое гном может спрятаться обратно в котёл")]
    public float PotHideMinTime;
    [Tooltip("Максимальное время, за которое гном может спрятаться обратно в котёл")]
    public float PotHideMaxTime;

    [Space(20f)]
    [Tooltip("Кол-во выбиваний для победы")]
    public int KnockedOutRequest;
    [Tooltip("Кол-во монеток за выбивание")]
    public int KnockReward;

    
}
