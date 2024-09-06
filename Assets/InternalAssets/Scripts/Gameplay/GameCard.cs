using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    [SerializeField] private CardGameManager gameManager;
    [SerializeField] private Image _myImage;
    [SerializeField] private Animator _animator;

    private bool isRevealed;

    private void OnValidate()
    {
        gameManager ??= FindObjectOfType<CardGameManager>();
        _myImage ??= GetComponent<Image>();
    }


    public void Interact()
    {
        if (isRevealed || CardGameManager.RevealCardsCount >= 2) return;
        
        isRevealed = true;
        _animator.Play("Reveal");
    }

    public void UpdateView()
    {
        _myImage.sprite = gameManager.GetSpriteReveal();
    }
}
