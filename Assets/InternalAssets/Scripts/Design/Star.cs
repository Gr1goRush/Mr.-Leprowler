using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    [SerializeField] private Sprite Deactivated;
    [SerializeField] private Sprite Activated;

    [SerializeField, HideInInspector] private Image image;

    private void OnValidate()
    {
        image ??= GetComponent<Image>();
        image.sprite = Deactivated;
    }

    public void Activate()
    {
        image.sprite = Activated;
    }
}
