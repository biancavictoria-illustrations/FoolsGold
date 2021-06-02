using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;    
/// <summary>
/// detects player death.
/// coupled with playerstats
/// </summary>
[RequireComponent(typeof(PlayerStats))]
public class PlayerDeath : MonoBehaviour
{
    
    /// <summary>
    /// The maximum Y to trigger a death. 
    /// </summary>
    public float DeathY;

    public UnityEvent OnDeath; 
    
    private PlayerStats _playerStats; 
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GetComponent<PlayerStats>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < DeathY && _playerStats.alive)
        {
            OnDeath.Invoke();
            _playerStats.alive = false; 
            print("Player has died. Press R to reset. //placeholder");
            
        }
    }
}
