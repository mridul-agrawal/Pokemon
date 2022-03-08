using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// This class is responsible to handle the Data Setup, UI & Animations for a battle unit (Pokemon) during the battle. 
/// </summary>
public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon Pokemon { get; set; }

    Image image;
    Vector3 originalPos;
    Color originalColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
        originalColor = image.color;
    }

    // This method Sets up pokemon attributes & UI for the battle.
    public void Setup()
    {
        Pokemon = new Pokemon(_base, level);
        if (isPlayerUnit)
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        else
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
        PlayerEnterAnimation();
        image.color = originalColor;
    }

    // performs player enter animation.
    public void PlayerEnterAnimation()
    {
        if (isPlayerUnit)
            image.transform.localPosition = new Vector3(-500, originalPos.y);
        else
            image.transform.localPosition = new Vector3(500, originalPos.y);
        image.transform.DOLocalMoveX(originalPos.x, 1f);
    }

    // performs player attack animation.
    public void PlayAttackAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        if (isPlayerUnit)
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x + 50, 0.25f));
        else
            sequence.Append(image.transform.DOLocalMoveX(originalPos.x - 50, 0.25f));
        sequence.Append(image.transform.DOLocalMoveX(originalPos.x, 0.25f));
    }

    // performs player hit animation.
    public void PlayHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.DOColor(Color.gray, 0.1f));
        sequence.Append(image.DOColor(originalColor, 0.1f));
    }

    // performs player faint animation.
    public void PlayFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOLocalMoveY(originalPos.y - 150, 0.5f));
        sequence.Join(image.DOFade(0f, 0.5f));
    }

}
