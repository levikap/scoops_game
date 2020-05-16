using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsBulletCollision : MonoBehaviour
{
    public GameObject[] lettersArray;
    public HexGrid hg;
    public string[] letters;
    private string currLetterString;
    private char currChar;
    protected int currLetterScore;
    bool gameOver;

    public BulletHandler bullet;

    // Start is called before the first frame update
    void Start()
    {
        hg = gameObject.AddComponent(typeof(HexGrid)) as HexGrid;
        this.lettersArray = hg.getLetterArray();
        this.letters = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i",
        "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
        "y", "z"};

        this.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (this.transform.position.y <= -8 && !gameOver)
        {
            print("Call is good.");
            gameOver = true;
            FindObjectOfType<StateManager>().GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //int letterInt = 0;
        if (col.gameObject.tag == "Bullet")
        {
            currLetterString = this.name;
            setCurrLetter(currLetterString);

            // the bullet hasn't collided with any balls yet
            if (bullet.collided == false)
            {
                //letterInt = this.findIndexOfLetter(currLetter);
                Destroy(gameObject);

            }
            //print(currLetterString);
            print(currChar);
            GameObject.Find("_Manager").GetComponent<HandleSubmit>().appendLetter(currChar.ToString());
            GameObject.Find("_Manager").GetComponent<HandleSubmit>().addPotentialLetterScore(currLetterScore);
            currLetterScore = 0;

        }
    }

    void setCurrLetter(string currLetterString)
    {
        switch(currLetterString)
        {
            case "A(Clone)":
                currChar = 'a';
                currLetterScore = 100;
                break;
            case "B(Clone)":
                currChar = 'b';
                currLetterScore = 300;
                break;
            case "C(Clone)":
                currChar = 'c';
                currLetterScore = 300;
                break;
            case "D(Clone)":
                currChar = 'd';
                currLetterScore = 200;
                break;
            case "E(Clone)":
                currChar = 'e';
                currLetterScore = 100;
                break;
            case "F(Clone)":
                currChar = 'f';
                currLetterScore = 400;
                break;
            case "G(Clone)":
                currChar = 'g';
                currLetterScore = 200;
                break;
            case "H(Clone)":
                currChar = 'h';
                currLetterScore = 400;
                break;
            case "I(Clone)":
                currChar = 'i';
                currLetterScore = 100;
                break;
            case "J(Clone)":
                currChar = 'j';
                currLetterScore = 800;
                break;
            case "K(Clone)":
                currChar = 'k';
                currLetterScore = 500;
                break;
            case "L(Clone)":
                currChar = 'l';
                currLetterScore = 100;
                break;
            case "M(Clone)":
                currChar = 'm';
                currLetterScore = 300;
                break;
            case "N(Clone)":
                currChar = 'n';
                currLetterScore = 100;
                break;
            case "O(Clone)":
                currChar = 'o';
                currLetterScore = 100;
                break;
            case "P(Clone)":
                currChar = 'p';
                currLetterScore = 300;
                break;
            case "Q(Clone)":
                currChar = 'q';
                currLetterScore = 1000;
                break;
            case "R(Clone)":
                currChar = 'r';
                currLetterScore = 100;
                break;
            case "S(Clone)":
                currChar = 's';
                currLetterScore = 100;
                break;
            case "T(Clone)":
                currChar = 't';
                currLetterScore = 100;
                break;
            case "U(Clone)":
                currChar = 'u';
                currLetterScore = 100;
                break;
            case "V(Clone)":
                currChar = 'v';
                currLetterScore = 400;
                break;
            case "W(Clone)":
                currChar = 'w';
                currLetterScore = 400;
                break;
            case "X(Clone)":
                currChar = 'x';
                currLetterScore = 800;
                break;
            case "Y(Clone)":
                currChar = 'y';
                currLetterScore = 400;
                break;
            case "Z(Clone)":
                currChar = 'z';
                currLetterScore = 1000;
                break;
            default:
                break;

        }
    }
}
