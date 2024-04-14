using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public bool runningTimer;
    public float currentTime;
    public float maxTime = 60;
    [SerializeField] TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        runningTimer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0)
        {
            // game over
            currentTime = 0;
            runningTimer = false;
            timerText.color = Color.red;
            timerText.text = "0:00";
            // implement game over
        }
        else
        {
            currentTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(currentTime / maxTime);
            int seconds = Mathf.FloorToInt(currentTime % maxTime);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
