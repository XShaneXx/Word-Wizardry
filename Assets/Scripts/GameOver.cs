using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    
    void Start()
    {
        scoreDisplay.text = TypingManger.score.ToString();
    }
}
