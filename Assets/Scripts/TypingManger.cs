using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypingManger : MonoBehaviour
{
    [Header("Word Display")]
    public TMP_Text wordDisplay;
    public TMP_Text nextWordDisplay;
    private string[] words = {
    "apple", "banana", "orange", "grape", "cherry",
    "strawberry", "kiwi", "blueberry", "watermelon", "pineapple",
    "elephant", "giraffe", "lion", "tiger", "zebra",
    "rhinoceros", "crocodile", "hippopotamus", "kangaroo", "platypus",
    "computer", "keyboard", "mouse", "monitor", "laptop",
    "desktop", "software", "hardware", "internet", "programming",
    "database", "algorithm", "function", "variable", "constant",
    "condition", "loop", "array", "string", "integer",
    "floating", "double", "boolean", "char", "spaceship",
    "alien", "galaxy", "astronaut", "universe", "planet",
    "star", "constellation", "comet", "asteroid", "telescope",
    "microscope", "laboratory", "experiment", "chemical", "molecule",
    "atom", "electron", "proton", "neutron", "energy",
    "power", "force", "motion", "velocity", "acceleration",
    "friction", "gravity", "weight", "mass", "density",
    "volume", "temperature", "pressure", "speed", "distance",
    "time", "clock", "calendar", "year", "month",
    "week", "day", "hour", "minute", "second",
    "century", "decade", "millennium", "past", "present",
    "future", "history", "geography", "mathematics", "science"
    };
    private string currentWord;
    private string nextWord;

    [Header("Player")]
    public TMP_InputField playerInput;
    public TMP_Text scoreDisplay;
    public float energy = 10f;
    public float maxEnergy = 100f;
    public Slider energySlider;

    [Header("Points")]
    public static int score = 0;
    public int consecutiveStrikes = 0;
    public float timer = 0f;
    public float strikeTimeThreshold = 5f;
    public Slider strikesSlider;
    public TMP_Text strikeDisplay;

    void Start()
    {
        SetRandomWords();

        // listen for "Enter" press
        playerInput.onEndEdit.AddListener(delegate { CheckInput(); }); 

        // select when scene start
        playerInput.Select();
    }

    void Update() 
    {
        // score display
        scoreDisplay.text = score.ToString();

        // energy slider
        energySlider.value = energy / maxEnergy;

        // strike timer
        timer += Time.deltaTime;

        if (timer >= strikeTimeThreshold)
        {
            consecutiveStrikes = 0;
            timer = 0f;
        }

        // strike slider & display
        strikesSlider.value = 5f - timer;
        strikeDisplay.text = "+" + consecutiveStrikes.ToString();

        // consume energy
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (energy >= 10)
            {
                energy -= 10;
            }
            else
            {
                Debug.Log("Not enough energy! - TypingManager");
            }
        }
    }

    void SetRandomWords()
    {
        currentWord = GetRandomWord();
        nextWord = GetRandomWord();
        
        wordDisplay.text = currentWord;
        nextWordDisplay.text = nextWord;
    }

    string GetRandomWord()
    {
        string randomWord;
        do
        {
            randomWord = words[Random.Range(0, words.Length)];
        } while (randomWord == currentWord || randomWord == nextWord);

        return randomWord;
    }

    public void CheckInput()
    {
        if (playerInput.text.Trim().ToLower() == currentWord.ToLower())
        {
            score += currentWord.Length * 100;

            if (timer <= strikeTimeThreshold)
            {
                consecutiveStrikes++;
                timer = 0f;
            }

            // updated new random word
            currentWord = nextWord;
            nextWord = GetRandomWord();

            // sliding words from next to current
            wordDisplay.text = currentWord;
            nextWordDisplay.text = nextWord;

            // refresh player input
            playerInput.text = "";
            playerInput.ActivateInputField();

            // energy
            if (consecutiveStrikes > 1)
            {
                int wordLength = currentWord.Length;
                int strikeBouns = wordLength + consecutiveStrikes - 1;
                energy += strikeBouns;
            }
            else
            {
                int wordLength = currentWord.Length;
                energy += wordLength;
            }

            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
        }
    }

    public float getEnergy()
    {
        return energy;
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public int getScore()
    {
        return score;
    }
}