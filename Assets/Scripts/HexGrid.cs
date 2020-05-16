using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

public class HexGrid : MonoBehaviour
{
    // the different letter objects to be generated in the grid
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;
    public GameObject E;
    public GameObject F;
    public GameObject G;
    public GameObject H;
    public GameObject I;
    public GameObject J;
    public GameObject K;
    public GameObject L;
    public GameObject M;
    public GameObject N;
    public GameObject O;
    public GameObject P;
    public GameObject Q;
    public GameObject R;
    public GameObject S;
    public GameObject T;
    public GameObject U;
    public GameObject V;
    public GameObject W;
    public GameObject X;
    public GameObject Y;
    public GameObject Z;

    // represents a random number to facilitate random letter generation
    public System.Random random = new System.Random();

    // the array of letters that can be generated
    public GameObject[] lettersArray;

    // the set of weights determining the likelihood of letters being generated
    public float[] weights;

    // a list of objects that have been instantiated
    public ArrayList instantiatedObjects = new ArrayList();

    // the number of letters (letter gameObjects) found per row of bubbles
    public int lettersPerRow;

    // the number of rows to generate initially
    public int numOfRows;

    // the most recently generated row number (the first row generated would be 1)
    public int rowOn;
    // the distance to move the rows down every time a new row is generated
    public float distanceMovedDown;

    // the radius to be used for generation
    public float radius = 1f;
    // determines whether to use the inner circle radius to generate or to just use the radius
    public bool useAsInnerCircleRadius = true;

    // the offset in the x and y directions to create rows slightly offset from each other
    private float offsetX, offsetY;

    // GameObject to hold all the cloned scoops
    public GameObject clonedGrids;

    public List<String> wordList = HandleSubmit.generateWordList();

    private Queue<String> wordLetterQueue = new Queue<string>();

    void Start()
    {
        this.distanceMovedDown = 0;
        this.rowOn = 0;
        InvokeRepeating("generateRowThenMoveDown", 2.0f, 10.0f);
        lettersArray = new GameObject[] {this.A, this.B, this.C, this.D, this.E, this.F,
        this.G, this.H, this.I, this.J, this.K, this.L, this.M, this.N, this.O, this.P,
        this.Q, this.R, this.S, this.T, this.U, this.V, this.W, this.X, this.Y, this.Z };

        float unitLength = (useAsInnerCircleRadius) ? (radius / (Mathf.Sqrt(3) / 2)) : radius;

        offsetX = (unitLength / 1.5f) * Mathf.Sqrt(3);
        offsetY = (unitLength / 1.5f) * 1.5f;
        for (int j = 0; j < 6; j++)
        {
            this.determineWordsForRow();
        }
        for (int i = 0; i < 3; i++)
        { 
            this.generateRow();
        }
    }

    // generates a new row of bubbles
    private void generateRow()
    {

        this.determineWordsForRow();
        // get the list of game objects to be generated for this row
        List<GameObject> gameObjectList = this.getGameObjectsToGenerate();
        // turn it into array for easier parsing
        GameObject[] gameObjectArray = gameObjectList.ToArray();
        // for every letter that needs to be generated in this row, generate it
        for (int i = 0; i < lettersPerRow; i++)
        {
            // calculate the offset for this row
            Vector2 hexpos = HexOffset(i, rowOn);
            // calculate the proper position to put this row
            Vector3 pos = new Vector3(hexpos.x - 2, (hexpos.y + 3) + distanceMovedDown, -0.5f);
            // get the object to generate
            GameObject generateMe = gameObjectArray[i];
            // if not null, instantiate the object
            if (generateMe != null)
            {
                GameObject obj = Instantiate(generateMe, pos, Quaternion.identity);
                obj.transform.parent = clonedGrids.transform;
                instantiatedObjects.Add(obj);
            }
        }

        this.rowOn++;
    }

    // used in the InvokeRepeating call
    // generates two rows of bubbles, then moves them down
    private void generateRowThenMoveDown()
    {
        this.moveRowsDown();
        this.generateRow();
    }

    // moves all the rows down a certain amount
    private void moveRowsDown()
    {
        float descentIncrement = -offsetY;
        foreach (GameObject g in instantiatedObjects)
        {
            if (g != null)
            {
                g.transform.position = g.transform.position + new Vector3(0, descentIncrement, 0);
            }
        }
        distanceMovedDown += descentIncrement;
    }


    // calculates the appropriate offset amount to create a grid of bubbles
    Vector2 HexOffset(int x, int y)
    {
        Vector2 position = Vector2.zero;

        if (y % 2 == 0)
        {
            position.x = x * offsetX;
            position.y = y * offsetY;
        }
        else
        {
            position.x = (x + 0.5f) * offsetX;
            position.y = y * offsetY;
        }

        return position;
    }

    // gets the list of game objects that are to be generated based on the word
    // selected
    private List<GameObject> getGameObjectsToGenerate()
    {
        List<GameObject> listOfGameObjects = new List<GameObject>();
        List<String> lettersToAdd = new List<string>();

        List<String> rowLettersToShuffle = new List<string>();
        for (int i = 0; i < lettersPerRow; i++)
        { 
            String s = this.wordLetterQueue.Dequeue();
            rowLettersToShuffle.Add(s);
            
        }

        while(rowLettersToShuffle.Count > 0)
        {
            int randLetterFromRow = random.Next(0, rowLettersToShuffle.Count);
            String[] rowLettersArray = rowLettersToShuffle.ToArray();
            lettersToAdd.Add(rowLettersArray[randLetterFromRow]);
            rowLettersToShuffle.Remove(rowLettersArray[randLetterFromRow]);
        }

        GameObject[] alphabetObjects = this.getLetterArray();
        // for every string in lettersToAdd, add the game object that corresponds to that string
            foreach (string s in lettersToAdd)
            {

                int indexInAlphabet = this.calculateAlphabetPos(s);
                listOfGameObjects.Add(alphabetObjects[indexInAlphabet]);
            }
        return listOfGameObjects;
    }

    private int calculateAlphabetPos(String s)
    {
        switch (s)
        {
            case "a":
                return 0;
            case "b":
                return 1;
            case "c":
                return 2;
            case "d":
                return 3;
            case "e":
                return 4;
            case "f":
                return 5;
            case "g":
                return 6;
            case "h":
                return 7;
            case "i":
                return 8;
            case "j":
                return 9;
            case "k":
                return 10;
            case "l":
                return 11;
            case "m":
                return 12;
            case "n":
                return 13;
            case "o":
                return 14;
            case "p":
                return 15;
            case "q":
                return 16;
            case "r":
                return 17;
            case "s":
                return 18;
            case "t":
                return 19;
            case "u":
                return 20;
            case "v":
                return 21;
            case "w":
                return 22;
            case "x":
                return 23;
            case "y":
                return 24;
            case "z":
                return 25;
            default:
                return 0;
        }
    }

    // gest the letter array used by this script
    public GameObject[] getLetterArray()
    {
        return new GameObject[] {this.A, this.B, this.C, this.D, this.E, this.F,
        this.G, this.H, this.I, this.J, this.K, this.L, this.M, this.N, this.O, this.P,
        this.Q, this.R, this.S, this.T, this.U, this.V, this.W, this.X, this.Y, this.Z };

    }

    private void determineWordsForRow()
    {
        // get a random word from the word list
        String s = getSuitableWord();
        print(s);

        // make a list of all the characters in the string that was chosen
        List<Char> charList = s.ToCharArray().ToList();

        // for every character in the string, turn it into a string and add that character to the queue
        for (int i = 0; i < charList.Count; i++) {
            String charAsString = charList.ElementAt(i).ToString();
            this.wordLetterQueue.Enqueue(charAsString);
        }
    }

    private String getSuitableWord()
    {
        int index = random.Next(0, wordList.Count);
        String s = wordList[index];
        if (s.Length > 7 || s.Length < 3)
        {
            return getSuitableWord();
        } else
        {
            return s;
        }
    }

    private List<String> addCharsToStringList(List<String> addToMe, string stringToAdd)
    {
        List<String> vowels = new List<String>() { "a", "e", "i", "o", "u" };


        if (stringToAdd.Length <= lettersPerRow - addToMe.Count)
        {
            List<Char> charArray = stringToAdd.ToCharArray().ToList();
            for (int i = 0; i < charArray.Count; i++)
            {
                int index2 = random.Next(0, charArray.Count);
                addToMe.Add(charArray.ElementAt(index2).ToString());
                charArray.RemoveAt(index2);
            }
            int index = random.Next(wordList.Count);
            String s = (string)wordList[index];
            return addCharsToStringList(addToMe, s);
        }
        else if (lettersPerRow - addToMe.Count < 3)
        {
            int index = random.Next(vowels.Count);
            string adding = vowels[index];
            addToMe.Add(adding);
            print("atm: " + addToMe);
            return addToMe;
        }
        else
        {
            int index = random.Next(wordList.Count);
            String s = (string)wordList[index];
            return addCharsToStringList(addToMe, s);
        }
    }



    // depricated but for posterity
    // selects what game object should be instantiated based on the specified weights
    private GameObject weightedSelectionOfGameObject()
    {
        float selected = UnityEngine.Random.Range(0.0f, 1.0f);
        for (int i = 0; i < weights.Length; i++)
        {
            int weightIndex = UnityEngine.Random.Range(0, weights.Length);
            if (weights[weightIndex] >= selected)
            {
                return lettersArray[weightIndex];
            }
        }
        return weightedSelectionOfGameObject();
    }
}
