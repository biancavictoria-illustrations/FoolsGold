using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Updates coin display with data from PlayerStats event. 
/// </summary>
public class CoinDisplay : MonoBehaviour
{
    private PlayerStats ps;

    private TextMeshProUGUI coinText;

    private string templateText = ""; 
    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        ps.OnCoinsChange.AddListener(UpdateCoinDisplay);
        
        coinText = GetComponent<TextMeshProUGUI>();
        templateText = coinText.text; 
    }

    // Update is called once per frame
    void UpdateCoinDisplay()
    {
        coinText.text = templateText.Replace("0", ps.Coins.ToString());
    }
}
