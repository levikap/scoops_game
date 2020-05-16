using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text currWord;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currWord.text = "Your letters: " + HandleSubmit.WORD.ToUpper();
        score.text = "Score: " + HandleSubmit.SCORE.ToString();

        //currWord.text = GameObject.Find("_Manager").GetComponent<HandleSubmit>().WORD;
        //score.text = GameObject.Find("_Manager").GetComponent<HandleSubmit>().SCORE.ToString();

    }
}
