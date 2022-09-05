using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] AudioClip GameOverSound;
    [SerializeField] GameObject WinningPointPlayer;
    [SerializeField] GameObject Player1ScoreText;
    [SerializeField] GameObject Player2ScoreText;
    [SerializeField] GameObject PlayerWinTextbox;
    public int Player1Score = 0;
    public int Player2Score = 0;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ball")
        {
            if(WinningPointPlayer.gameObject.name.Contains("Player1"))
            {
                Player1Score++;
                Player1ScoreText.GetComponent<TextMeshProUGUI>().SetText(Player1Score.ToString());
            }
            if (WinningPointPlayer.gameObject.name.Contains("Player2"))
            {
                Player2Score++;
                Player2ScoreText.GetComponent<TextMeshProUGUI>().SetText(Player2Score.ToString());
            }
            CheckPlayerWinCondition();
        }
    }

    private void CheckPlayerWinCondition()
    {
        if(Player1Score >= 10)
        {
            PlayerWinTextbox.GetComponent<TextMeshProUGUI>().SetText("Player 1 Wins. Press R to restart.");
            RestartGame();
        }
        if (Player2Score >= 10)
        {
            PlayerWinTextbox.GetComponent<TextMeshProUGUI>().SetText("Player 2 Wins. Press R to restart.");
            RestartGame();
        }
    }

    private void RestartGame()
    {
        Time.timeScale = 0;
        FindObjectOfType<AudioPlayer>().PlaySound(GameOverSound);
        FindObjectOfType<PlayerController>().IsGameOver = true;
    }
}
