using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon Pokemon { get; set; }

    Image image;
    Vector3 originalPos;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalPos = image.transform.localPosition;
    }

    public void Setup()
    {
        Pokemon = new Pokemon(_base, level);
        if (isPlayerUnit)
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        else
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
        PlayerEnterAnimation();
    }

    public void PlayerEnterAnimation()
    {
        if (isPlayerUnit)
            image.transform.localPosition = new Vector3(-500, originalPos.y);
        else
            image.transform.localPosition = new Vector3(500, originalPos.y);
        image.transform.DOLocalMoveX(originalPos.x, 1f);
    }

}
