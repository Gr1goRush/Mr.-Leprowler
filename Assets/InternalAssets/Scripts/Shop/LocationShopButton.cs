using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationShopButton : PurchaseButton
{
    public static Action OnChoosed;
    [SerializeField] private int _locationID;

    [Header("Parametres")]
    [SerializeField, HideInInspector] private Image _image;

    [Header("Sprites")]
    [SerializeField] private Sprite _lockedSprite;
    [SerializeField] private Sprite _selectSprite;
    [SerializeField] private Sprite _selectedSprite;

    private void OnValidate()
    {
        _image ??= GetComponent<Image>();
    }

    private void OnEnable()
    {
        LocationShopButton.OnChoosed += SetUnchosed;

    }
    private void OnDisable()
    {
        LocationShopButton.OnChoosed -= SetUnchosed;
    }

    public override void Start()
    {
        base.Start();
        if (_locationID == 0) Unlock();
        SetUnchosed();
        UpdateInfo();
        BackGroundLoader.ChooseBackGround(PlayerPrefs.GetInt("ChosenBG"));

    }

    public override void Interact()
    {
        base.Interact();
    }

    public override void OnPurchaseInvoke()
    {
        base.OnPurchaseInvoke();
        SetUnchosed();
    }

    public override void OnPurchasedInvoke()
    {
        BackGroundLoader.ChooseBackGround(_locationID);
        PlayerPrefs.SetInt("ChosenBG", _locationID);
        OnChoosed?.Invoke();
        Debug.Log("SetNew Background");
        SetUnchosed();
    }

    public void SetUnchosed()
    {
        if (!IsPurchased) return;
        

        if (PlayerPrefs.GetInt("ChosenBG") == _locationID)
        {
            
            _image.sprite = _selectedSprite;
        }
        else
        {
            _image.sprite = _selectSprite;
        }
    }
    
}
