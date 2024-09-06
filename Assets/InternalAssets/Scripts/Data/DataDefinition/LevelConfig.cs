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
    [Tooltip("���-�� �������� � �����������")]
    [Range(1, 9)] public int PotsCount;
    [Tooltip("������� �����, �� ��������� ������� \n ������� ��������")]
    public int GameTime;

    [Space(20f)]
    [Tooltip("����������� �����, �� ������� ���� ����� ������� �� �����")]
    public float PotRevealMinTime;
    [Tooltip("������������ �����, �� ������� ���� ����� ������� �� �����")]
    public float PotRevealMaxTime;

    [Space(20f)]
    [Tooltip("����������� �����, �� ������� ���� ����� ���������� ������� � ����")]
    public float PotHideMinTime;
    [Tooltip("������������ �����, �� ������� ���� ����� ���������� ������� � ����")]
    public float PotHideMaxTime;

    [Space(20f)]
    [Tooltip("���-�� ��������� ��� ������")]
    public int KnockedOutRequest;
    [Tooltip("���-�� ������� �� ���������")]
    public int KnockReward;

    
}
