using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Pokemon", menuName = "Pokemon/Create New Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string _name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    //Base Stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spattack;
    [SerializeField] int spdefense;
    [SerializeField] int speed;

    public string Name
    {
        get { return _name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public PokemonType Type1
    {
        get { return Type1; }
    }

    public PokemonType Type2
    {
        get { return Type2; }
    }

    public int MaxHP
    {
        get { return maxHP; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int SPAttack
    {
        get { return spattack; }
    }

    public int SPDefense
    {
        get { return spdefense; }
    }

    public int Speed
    {
        get { return speed; }
    }

}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Grass,
    Rock,
    Metal,
    Ice,
    Fighting,
    Electric,
    Poison,
    Ground,
    Psychic,
    Bug,
    Ghost,
    Dragon
}
