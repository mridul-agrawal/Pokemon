using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    PokemonBase _base;
    int level;
    public int HP;

    public List<Move> Moves { get; set; }

    Pokemon(PokemonBase pbase, int plevel)
    {
        _base = pbase;
        level = plevel;
        HP = _base.MaxHP;

        Moves = new List<Move>();
        foreach(var move in _base.LearnableMoves)
        {
            if(move.Level <= level)
            {
                Moves.Add(new Move(move.Base));
            }
            if (Moves.Count >= 4)
                break;
        }
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defense * level) / 100f) + 5; }
    }

    public int SPAttack
    {
        get { return Mathf.FloorToInt((_base.SPAttack * level) / 100f) + 5; }
    }

    public int SPDefense
    {
        get { return Mathf.FloorToInt((_base.SPDefense * level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }

    public int MaxHP
    {
        get { return Mathf.FloorToInt((_base.MaxHP * level) / 100f) + 10; }
    }

}
