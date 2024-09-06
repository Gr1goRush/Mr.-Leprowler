using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public static event Action OnSuperGameCharge;
    public static event Action OnUnitKnockedOut;
    public static event Action<Vector3> OnUnitTakeDamage;

    

    [SerializeField] private UnitStage stage;
    [SerializeField] private ParticleSystem _hatParticle;

    public UnitStage Stage => stage;
    public LevelConfig LevelConfig { get; private set; }

    public static bool SomebodyEscaped = false;

    private bool _takeDamageAlready = false;

    [Header("UnitParametres")]
    [SerializeField] private bool isRedUnit = false;
    [SerializeField] private Image _unitImage;
    [SerializeField] private Sprite[] _healthStages;
    [SerializeField] private Sprite _redUnitSprite;
    [SerializeField] private Animator _Unitanimator;
    private int _health = 3;

    [Header("OtherStats")]
    [SerializeField] private Transform _hammerSpot;


    public void SetUnitAsRed()
    {
        isRedUnit = true;
        _unitImage.sprite = _redUnitSprite;
    }

    public void UpdateStage()
    {
        if (GameManager.IsGamePaused) return;
        switch (stage)
        {
            case UnitStage.Empty:
                stage = UnitStage.LookOut;
                //ResetStats();
                UpdateView();
                _Unitanimator.Play("LookOutTransit");
                _takeDamageAlready = false;
                break;

            case UnitStage.LookOut:
                stage = UnitStage.GotOut;
                UpdateView();
                _Unitanimator.Play("GotOutTransit");
                break;

            case UnitStage.GotOut:

                if (_health <= 0) break;
                stage = UnitStage.Empty;
                UpdateView();
                _Unitanimator.Play("HideBackTransit");

                if (isRedUnit)
                {
                    isRedUnit = false;
                }
                else if (!_takeDamageAlready)
                {
                    SomebodyEscaped = true;
                }

                break;
        }
    }

    public void SetStage(UnitStage stage) 
    { 
        this.stage = stage;
    }

    public void UpdateView()
    {
        if (isRedUnit) return;
        _unitImage.sprite = _healthStages[_health];
    }

    public void Interact()
    {
        if (GameManager.IsGamePaused) return;
        if (_health <= 0 || _takeDamageAlready) return;

        //Debug.Log("Interact");
        if (stage == UnitStage.GotOut)
        {
            if (!isRedUnit)
            {
                Vibration.PlayVibro();
                _takeDamageAlready = true;
                OnUnitTakeDamage?.Invoke(_hammerSpot.position);
                _health -= 1;
                UpdateView();
                UpdateStage();

                if (_health == 1) _hatParticle.Play();

                if (_health == 0)
                {
                    UpdateView();
                    _Unitanimator.Play("KnockedOut");
                    OnUnitKnockedOut?.Invoke();
                    Invoke("ResetStats", 1);
                    
                }
            }
            else
            {
                _takeDamageAlready = true;
                Vibration.PlayVibro();
                OnUnitTakeDamage?.Invoke(_hammerSpot.position);
                _Unitanimator.Play("KnockedOut");
                Invoke("CallSupergameEvent", 1f);
                isRedUnit = false;
                Invoke("ResetStats", 1);
            }
        }
    }

    private void OnMouseDown()
    {
        Interact();
    }

    public void SetConfig(LevelConfig config)
    {
        LevelConfig = config;

        if (TryGetComponent<UnitAutoStage>(out UnitAutoStage Auto))
        {
            Auto.InizializeConfig();
        }
    }

    public void ResetStats()
    {
        _health = 3;
    }

    public void ResetAll()
    {
        ResetStats();
        stage = UnitStage.Empty;
        UpdateView();
    }

    public void CallSupergameEvent()
    {
        OnSuperGameCharge?.Invoke();
    }
}

public enum UnitStage
{
    Empty,
    LookOut,
    GotOut,
    RedGotOut
}
