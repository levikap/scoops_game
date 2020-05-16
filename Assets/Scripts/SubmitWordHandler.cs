using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SubmitWordHandler : MonoBehaviour
{
    public Button Plus;
    // Start is called before the first frame update
    void Start()
    {
        Button button = Plus.GetComponent<Button>();
        //button.onClick.AddListener(handleWord);

    }

    // Checks to see if the word submitted is actually a word.
    // Handles this information accordingly.
    public void handleWord(string word)
    {
        string str = word.ToLower();

        if (isWord(str) == 1)
        {
            print("1");
        }
        else
        {
            print("0");
        }


    }

    // Checks to see if the String given is a word.
    public int isWord(string str)
    {
        string line;
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
                        if (string.Compare(str, line) == 0)
                        {
                            reader.Close();
                            return 1;
                        }
                    }
                }
                while (line != null);
                reader.Close();
                return 0;
            }
        } catch(IOException e) 
        {
            return 0;
        }
    }
  
}