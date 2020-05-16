using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class HandleSubmit : MonoBehaviour
{
    public static string WORD = "";

    public static int SCORE = 0;

    public static List<string> wordList;

    protected int potentialLetterScore;

    private void Start()
    {
        wordList = generateWordList();
    }

    public static List<string> generateWordList()
    {

        string line;

        wordList = new List<String>();
        // Creates a StreamReader to iterate through the words list.
        StreamReader reader = new StreamReader("google-10000-english-usa-no-swears.txt", Encoding.Default);

        try
        {
            using (reader)
            {
                do
                {
                    line = reader.ReadLine();

                    if (line != null)
                    {
                        wordList.Add(line);
                    }
                }
                while (line != null);
                reader.Close();

            }
        }
        catch (IOException e)
        {
            print(e);
        }

        return wordList;
    }

    // Checks to see if the word submitted is actually a word.
    // Handles this information accordingly.
    public void handleSubmit()
    {
        print("handle called");
        if (wordList.Contains(WORD.ToLower()))
        {
            if (WORD.Length > 1)
            {
                GameObject.Find("_Manager").GetComponent<IncrementScore>().incrementScore(potentialLetterScore);
                SCORE += potentialLetterScore;
            }
            potentialLetterScore = 0;
            WORD = "";
        }
        else
        {
            potentialLetterScore = 0;
            WORD = "";
        }
    }

    public void appendLetter(string l)
    {
        WORD += l;
        print(WORD);
    }

    public void addPotentialLetterScore(int currLetterScore)
    {
        potentialLetterScore += currLetterScore;
    }

}
