using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores player stats:
/// gold, alive state 
/// </summary>
public class PlayerStats : MonoBehaviour
{

    public int coins;
    public bool alive;

    private void Start()
    {
        alive = true; 
    }
}
