using UnityEngine;
using UnityEngine.UI;
public class CardGameManager : MonoBehaviour
{
    private bool isPlayerWin;
    private int chachedWinCard;
    private int chachedLoseCard;

    private static int revealCardsCount;
    public static int RevealCardsCount => revealCardsCount;

    [SerializeField] private Sprite[] cardsFrontSide;


    private void Start()
    {
        revealCardsCount = 0;
        isPlayerWin = Random.Range(0, 6) == 0;

        chachedWinCard = Random.Range(0, cardsFrontSide.Length);
        chachedLoseCard = chachedWinCard - 1 > 0 ? chachedWinCard - 1 : chachedWinCard + 1;
    }

    public Sprite GetSpriteReveal()
    {
        revealCardsCount++;

        if (isPlayerWin)
        {
            if (revealCardsCount == 2) Invoke("EndGameEvent", 3);
            return cardsFrontSide[chachedWinCard];
        }
        else
        {
            if (revealCardsCount == 1)
            {
                return cardsFrontSide[chachedWinCard];
            }
            else
            {
                Invoke("EndGameEvent", 3);
                return cardsFrontSide[chachedLoseCard];
            }
        }
    }


    public void EndGameEvent()
    {
        if (isPlayerWin)
        {
            ProgressSave.OpenNewLevel();
            GameScene.LoadMenu(3);

        }
        else
        {
            GameScene.LoadGame();
        }

        

        
    }

    
}
