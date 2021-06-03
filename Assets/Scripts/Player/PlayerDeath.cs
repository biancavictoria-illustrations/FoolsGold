using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public TimerDisplay timerDisplay;
    float timer;


    
    private PlayerStats _playerStats; 
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        timer = timerDisplay.GetComponent<TimerDisplay>().time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (transform.position.y < DeathY && _playerStats.Alive || timer <= 0f)
        {
            _playerStats.Alive = false;
            SceneManager.LoadScene("DeadScene");
            //print("Player has died. Press R to reset. //placeholder");
            
        }
    }
}
