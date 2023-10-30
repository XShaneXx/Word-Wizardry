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
    private string[] words = { "apple", "banana", "orange", "grape", "cherry" };
    private string currentWord;
    private string nextWord;

    [Header("Player")]
    public TMP_InputField playerInput;
    public int score = 0;
    public TMP_Text scoreDisplay;

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
        scoreDisplay.text = score.ToString();
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
        if (playerInput.text.Trim() == currentWord)
        {
            score += 100;

            // updated new random word
            currentWord = nextWord;
            nextWord = GetRandomWord();

            // sliding words from next to current
            wordDisplay.text = currentWord;
            nextWordDisplay.text = nextWord;

            // refresh player input
            playerInput.text = "";
            playerInput.ActivateInputField();
        }
    }
}
