using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public bool runningTimer;
    public float currentTime;
    public float maxTime = 60;
    [SerializeField] TextMeshProUGUI timerText;
    public gameOverScreen gameOver;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        runningTimer = true;
        gameOver = new gameOverScreen();
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
            timerText.text = "00:00";
            // implement game over
            Gameover();
        }
        else
        {
            currentTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(currentTime / maxTime);
            int seconds = Mathf.FloorToInt(currentTime % maxTime);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void Gameover()
    {
        if (gameOver == null)
            Debug.Log(gameOver);
        else
            gameOver.setup(10);
    }
}
