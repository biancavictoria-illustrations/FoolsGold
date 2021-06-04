using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public GameObject pausedDisplay; 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = Time.timeScale == 1f ? 0 : 1;
            pausedDisplay.SetActive(Time.timeScale == 0);
        }
    }
}
