using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numberwizard : MonoBehaviour
{
    int min = 1;
    int max = 100;
    int guess;
    int attempts = 0; 
    bool gameOver = false; 


    void Start()
    {
        StartGame();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !gameOver)
        {
            Lower();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !gameOver)
        {
            Higher();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (gameOver)
            {
                StartGame();  
            }
            else
            {
                Debug.Log("is het nummer waar je aan dacht" + guess);
                gameOver = true; 
            }
        }
    }

    void StartGame()
    {
        min = 1;
        max = 100;
        guess = (max + min) / 2;
        attempts = 0; 
        gameOver = false; 

        Debug.Log("<color=#ADD8E6>" + "Welkom bij Number Wizard!" + "</color>");
        Debug.Log("<color=#ADD8E6>" + "Kies een nummer in je hoofd, maar vertel het me niet!" + "</color>");
        Debug.Log("<color=#ADD8E6>" + "Het hoogste nummer dat je kunt kiezen is: " + max + "</color>");
        Debug.Log("<color=#ADD8E6>" + "Het laagste nummer dat je kunt kiezen is: " + min + "</color>");
        Debug.Log("<color=#ADD8E6>" + "Druk op de pijl-omhoog als je nummer hoger is." + "</color>");
        Debug.Log("<color=#ADD8E6>" + "Druk op de pijl-omlaag als je nummer lager is." + "</color>");
        Debug.Log("<color=#ADD8E6>" + "Druk op Enter als mijn gok correct is." + "</color>");

        NextGuess();
    }

    void NextGuess()
    {
        attempts++; 
        Debug.Log("Is je nummer" + guess + "?");

        if (attempts > 5) 
        {
            Debug.Log("Jij wint! ik heb te veel pogingen gedaan");
            gameOver = true;  
        }
    }

    void Higher()
    {
        min = guess + 1;  
        guess = (max + min) / 2;
        NextGuess();
    }

    void Lower()
    {
        max = guess - 1;  
        guess = (max + min) / 2;
        NextGuess();
    }
}