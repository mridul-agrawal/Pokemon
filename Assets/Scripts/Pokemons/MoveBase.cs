using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create New Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string _name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] PokemonType moveType;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name { get { return _name; } }

    public string Description { get { return description; } }

    public PokemonType MoveType { get { return moveType; } }

    public int Power { get { return power; } }

    public int Accuracy { get { return accuracy; } }

    public int PP { get { return pp; } }
}
