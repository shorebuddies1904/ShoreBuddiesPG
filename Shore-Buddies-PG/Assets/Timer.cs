using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 


public class Timer : MonoBehaviour
{
    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public float timeLeft;
    public bool timerOn;
    public TMP_Text timerText;

    void Start() 
    {
        timerOn = true;
    }

    void Update() 
    {
        if(timerOn) 
        {
            if(timeLeft > 0) 
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else 
            {
            Debug.Log("Time is up!");
            SceneManager.LoadScene("EndScene");
            timeLeft = 0;
            timerOn = false;
            }
        }
        
    }

    void UpdateTimer(float currentTime) 
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60); 
        float seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    
}
