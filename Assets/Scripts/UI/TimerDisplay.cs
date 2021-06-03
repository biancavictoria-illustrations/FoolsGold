using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{

    public float time = 60;
    bool timerOn;
    private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (time > 0) {
                time -= Time.deltaTime;
                timerText.text = "Time: " + Mathf.FloorToInt(time % 60f).ToString();
            }
            else
            {
                time = 0;
                timerText.text = "Time: " + Mathf.FloorToInt(time % 60f).ToString();
                timerOn = false;
            }
        }
    }
}
