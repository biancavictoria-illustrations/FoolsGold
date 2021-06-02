using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;   


/// <summary>
/// Stores player stats:
/// gold, alive state
/// and provides unity events for them 
/// </summary>
public class PlayerStats : MonoBehaviour
{

    public int Coins
    {
        get => _coins;
        set
        {
            _coins = value; 
            OnCoinsChange.Invoke();
        }
    }

    public bool Alive
    {
        get => _alive;

        set
        {
            _alive = value; 
            OnDeath.Invoke();
        }
    }
    
    //UnityEvents. Use these to extend functionality. 

    public UnityEvent OnDeath;
    public UnityEvent OnCoinsChange; 
    

    private bool _alive = true;
    private int _coins = 0; 
    
    
    private void Start()
    {
        Alive = true; 
    }
}
