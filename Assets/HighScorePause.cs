using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string highScore = "" + PlayerPrefs.GetInt("highscore", 0);
        GameObject.Find("highScore").GetComponent<Text>().text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        string highScore = "" + PlayerPrefs.GetInt("highscore", 0);
        GameObject.Find("highScore").GetComponent<Text>().text = "High Score: " + highScore;
    }
}
