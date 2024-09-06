using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image image;
    [SerializeField] private float SpeedMultiply;
    [ContextMenu("Play")]
    public void Play()
    {

        image.enabled = true;
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            image.sprite = sprites[i];
            yield return new WaitForSeconds(Time.deltaTime / SpeedMultiply);
        }
        image.enabled = false;
    }

    public void SetNewList(Sprite[] sprites)
    {
        this.sprites = sprites;
    }
}
