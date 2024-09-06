using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AnimationPlayer))]
public class HammerScriptLoader : MonoBehaviour
{
    public UnityEvent OnComplete;

    public static int ChosenSkin = 0;
    [SerializeField] private AnimationPlayer _animationPlayer;

    [Space(20f)]
    [SerializeField] private HammerSkin[] hammerSkins; 

    private void OnValidate()
    {
        _animationPlayer ??= GetComponent<AnimationPlayer>();
    }

    private void Start()
    {
        _animationPlayer.SetNewList(hammerSkins[ChosenSkin].spritesArray);
    }

    private void OnEnable()
    {
        Unit.OnUnitTakeDamage += GotoTouch;
    }

    private void OnDisable()
    {
        Unit.OnUnitTakeDamage -= GotoTouch;
    }

    public void GotoTouch(Vector3 TouchPos)
    {
        TouchPos.z = 0;
        transform.position = TouchPos;
        _animationPlayer.Play();
        OnComplete?.Invoke();
    }

    public static void SetChosenSkin(int id)
    {
        ChosenSkin = id;
    }
}
