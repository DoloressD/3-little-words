using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsController : MonoBehaviour
{
    public Text [] words;
    public Text guessDisplay;
    public GameObject winPanel;
    public static string playerGuess = "";
    private List<Text> lastGuess = new List<Text>();
    private int correctGuesses = 0;

    public void SetPlayerGuess(Text thisText)
    {
        if (playerGuess.Length < 15)
        {
            lastGuess.Add(thisText);
            thisText.gameObject.SetActive(false);
            playerGuess += thisText.text;
            guessDisplay.text = playerGuess;
            CheckWord();
        }
    }

    public void RemoveLastGuess()
    {
        if(lastGuess.Count>0)
        {
            int lastGuessIndex = lastGuess.Count - 1;
            playerGuess = playerGuess.Replace(lastGuess[lastGuessIndex].text, "");
            lastGuess[lastGuessIndex].gameObject.SetActive(true);
            lastGuess.RemoveAt(lastGuessIndex);
            guessDisplay.text = playerGuess;
        }
    }

    private void CheckWord()
    {
        for (int i = 0; i < words.Length; i++)
        {
            if (string.Equals(words[i].text, playerGuess, System.StringComparison.OrdinalIgnoreCase))
            {
                words[i].gameObject.SetActive(true);
                ResetGuess();
                correctGuesses++;
                CheckWin();
            }
        }
    }

    private void ResetGuess()
    {
        playerGuess = "";
        guessDisplay.text = playerGuess;
        lastGuess.Clear();       
    }

    private void CheckWin()
    {
        if(correctGuesses == 7)
        {
            winPanel.SetActive(true);
        }
    }

}
