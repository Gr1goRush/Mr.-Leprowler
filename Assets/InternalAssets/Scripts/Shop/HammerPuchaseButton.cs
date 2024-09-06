using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HammerPuchaseButton : PurchaseButton
{
    public static Action OnChoosedWeapon;
    [SerializeField] private int _WeaponID;

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
        HammerPuchaseButton.OnChoosedWeapon += SetUnchosed;

    }
    private void OnDisable()
    {
        HammerPuchaseButton.OnChoosedWeapon -= SetUnchosed;
    }

    public override void Start()
    {
        base.Start();
        if (_WeaponID == 0) Unlock();
        SetUnchosed();
        UpdateInfo();
        HammerScriptLoader.SetChosenSkin(PlayerPrefs.GetInt("ChosenWP"));
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
        HammerScriptLoader.SetChosenSkin(_WeaponID);
        PlayerPrefs.SetInt("ChosenWP", _WeaponID);
        OnChoosedWeapon?.Invoke();
        Debug.Log("SetNew WEAPON");
        SetUnchosed();
    }

    public void SetUnchosed()
    {
        if (!IsPurchased) return;


        if (PlayerPrefs.GetInt("ChosenWP") == _WeaponID)
        {

            _image.sprite = _selectedSprite;
        }
        else
        {
            _image.sprite = _selectSprite;
        }
    }
}
