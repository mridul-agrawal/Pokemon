using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class loads the data from a MoveBase SO in a referencable object.
/// </summary>
public class Move 
{
    public MoveBase Base { get; set; }

    public int PP { get; set; }

    public Move(MoveBase _base)
    {
        Base = _base;
        PP = _base.PP;
    }
}
