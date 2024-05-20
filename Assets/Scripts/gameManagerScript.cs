using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject PauseMenu;
    public GameObject victoryScreen;
    public GameObject backgroundMusic;
    public GameObject ParticleSystem;
    public TextMeshProUGUI statText;
    timer gameTime;
    public bool isPaused;
    [SerializeField] private AudioClip victorySound;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // game over
    public void quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void victory()
    {
        backgroundMusic.SetActive(false);
        var pS = GetComponent<ParticleSystem>();
        if (pS != null)
        {
            pS.Play();
        }
        soundManager.instance.PlaySound(victorySound);
        float timeReversed = gameTime.returnReversedTime();
        statText.text += timeReversed;
        victoryScreen.SetActive(true);
    }
}
