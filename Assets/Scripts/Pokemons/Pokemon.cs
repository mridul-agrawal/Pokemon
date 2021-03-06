using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for loading data & performing functionality related to a Pokemon.
/// </summary>
public class Pokemon
{
    public PokemonBase Base { get; set; }
    public int Level { get; set; }
    public int HP;

    public List<Move> Moves { get; set; }

    public Pokemon(PokemonBase pbase, int plevel)
    {
        Base = pbase;
        Level = plevel;
        HP = MaxHP;

        Moves = new List<Move>();
        foreach(var move in Base.LearnableMoves)
        {
            if(move.Level <= Level)
            {
                Moves.Add(new Move(move.Base));
            }
            if (Moves.Count >= 4)
                break;
        }
    }

    public int Attack { get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; } }
    public int Defense { get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5; } }
    public int SPAttack { get { return Mathf.FloorToInt((Base.SPAttack * Level) / 100f) + 5; } }
    public int SPDefense { get { return Mathf.FloorToInt((Base.SPDefense * Level) / 100f) + 5; } }
    public int Speed { get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5; } }
    public int MaxHP { get { return Mathf.FloorToInt((Base.MaxHP * Level) / 100f) + 10; } }


    // This Method calculates the damage to be inflicted by taking multiple parameters in account.
    public DamageDetails TakeDamage(Move move, Pokemon attacker)
    {
        float critical = 1f;
        if(Random.value * 100 <= 6.25f)
        {
            critical = 2f;
        }

        float type = TypeChart.GetEffectiveness(move.Base.MoveType, this.Base.Type1) * TypeChart.GetEffectiveness(move.Base.MoveType, this.Base.Type2);

        var damageDetails = new DamageDetails()
        {
            Fainted = false,
            TypeEffectiveness = type,
            Critical = critical
        };

        float modifiers = Random.Range(0.85f, 1f) * type * critical;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);
        HP -= damage;
        if(HP <= 0)
        {
            HP = 0;
            damageDetails.Fainted = true;
        } 
        
        return damageDetails;
        
    }

    // Returns a random move from the list to perform
    public Move GetRandomMove()
    {
        int r = Random.Range(0,Moves.Count);
        return Moves[r];
    }

}

/// <summary>
/// Instance of this class holds details for the damage inflicted.
/// </summary>
public class DamageDetails
{
    public bool Fainted { get; set; }
    public float Critical { get; set; }
    public float TypeEffectiveness { get; set; }
}
