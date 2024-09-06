using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : PurchaseButton
{

    [SerializeField] private int levelID;
    [SerializeField] private LevelConfig levelConfig;


    [Space(10f)]
    [SerializeField] private Text levelNameText;
    [SerializeField] private Star[] starsArray;


    [Header("PlayButton")]
    [SerializeField] private Image playButtonImage;
    [SerializeField] private Sprite _lockedSprite;
    [SerializeField] private Sprite _unlockedSprite;

    private void OnValidate()
    {
        levelNameText.text = $"Level {levelID + 1}";
    }

    public override void Start()
    {
        base.Start();
        bool IsCompleted = ProgressSave.LevelIsCompleted(levelConfig.LevelName, out int stars);
        //Debug.Log(stars);
        for (int i = 0; i < stars; i++)
        {
            starsArray[i].Activate();
        }

        UpdateView();
      
    }


    public override void OnPurchaseInvoke()
    {
        base.OnPurchaseInvoke();
        Unlock();
        UpdateView();
    }
    public override void OnPurchasedInvoke()
    {
        //Unlock();
        GameManager.SetLevelConfig(levelConfig);
        GameScene.LoadGame();
        
    }

    public override void Interact()
    {
        base.Interact();
    }

    private void UpdateView()
    {
        if (ProgressSave.CompletedLevelsCount() < levelID)
        {
            playButtonImage.gameObject.SetActive(false);
        }
        else if (IsPurchased || levelID == 0)
        {
            _costText.gameObject.SetActive(false);
            Unlock();
            playButtonImage.sprite = _unlockedSprite;
        }
        else
        {
            _costText.text = _itemCost.ToString();
            playButtonImage.sprite = _lockedSprite;
        }
    }
}
