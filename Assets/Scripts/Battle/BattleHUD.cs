using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] Text NameText;
    [SerializeField] Text LevelText;
    [SerializeField] HPBar hpBar;

    Pokemon _pokemon;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;
        NameText.text = pokemon.Base.Name;
        LevelText.text = "Lvl " + pokemon.Level;
        hpBar.SetHP((float) pokemon.HP / pokemon.MaxHP);
    }

    public void UpdateHP()
    {
        hpBar.SetHP((float)_pokemon.HP / _pokemon.MaxHP);
    }
}
