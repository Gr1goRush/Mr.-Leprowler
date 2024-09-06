using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoader : MonoBehaviour
{
    private static int chosenBackGround;
    [SerializeField] private GameObject[] backGroundsArray;
    public static int ChosenBackGround => chosenBackGround;
    public static void ChooseBackGround(int id)
    {
        chosenBackGround = id;
    }

    private void Start()
    {
        foreach (var backGround in backGroundsArray) { backGround.gameObject.SetActive(false);}
        backGroundsArray[chosenBackGround].gameObject.SetActive(true);
    }
}
