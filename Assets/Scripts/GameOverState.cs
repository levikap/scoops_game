using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : MonoBehaviour
{
    
    // Switches the game scene to that of a new game.
    public void playAgain()
    {
        print("Play Again");
        SceneManager.LoadScene("WordBubble");
        HandleSubmit.SCORE = 0;
        PlayerPrefs.SetInt("score", 0);
    }

    // Switches the game scene to that of the home screen.
    public void homeScreen()
    {

    }
}
