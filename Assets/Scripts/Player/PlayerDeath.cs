using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
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


    
    private PlayerStats _playerStats; 
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GetComponent<PlayerStats>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < DeathY && _playerStats.Alive)
        {
            _playerStats.Alive = false; 
            print("Player has died. Press R to reset. //placeholder");
            
        }
    }
}
