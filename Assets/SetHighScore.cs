using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighScore : MonoBehaviour
{



    private void Awake()
    {
        string highScore = "" + PlayerPrefs.GetInt("highscore", 0);
        GameObject.Find("HighScoreText").GetComponent<Text>().text = "High Score: " + highScore;

        string score = "" + PlayerPrefs.GetInt("score", 0);
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + score;


    }
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
