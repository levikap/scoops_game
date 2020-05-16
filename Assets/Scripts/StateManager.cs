
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gamePlay;
    public static bool paused;
    public static bool playingAgain;


    public void Start()
    {
        paused = false;
        playingAgain = false;
    }

    public void GameOver()
    {
        bool gameOver = false;

        if (!gameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }

    public void pauseGame()
    {

        if (paused)
        {
            pauseMenu.SetActive(false);
            gamePlay.SetActive(true);
            paused = !paused;
            playingAgain = true;
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            gamePlay.SetActive(false);
            paused = !paused;
            playingAgain = false;
            Time.timeScale = 0;
        }


    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
