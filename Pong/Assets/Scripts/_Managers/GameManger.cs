using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Puddle;
    public GameObject player1Goal;


    [Header("Player 2")]
    public GameObject player2Puddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public GameObject player1Text;
    public GameObject player2Text;

    private static GameManger sharedInstance;
    private bool isPaused = false;
    private int player1Score;
    private int player2Score;

    private void Awake()
    {
        sharedInstance = this;

        GameObject.Find("Player 2").GetComponent<Puddle>().IsMulitplayer = PlayerPrefs.GetInt("is_mulitplayer", 0) == 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeOrPauseGame();
        }
    }

    public void Player1Scored()
    {
        player1Score++;
        player1Text.GetComponent<TextMeshProUGUI>().text = player1Score.ToString();
        ResetPosition();
    }

    public void Player2Scored()
    {
        player2Score++;
        player2Text.GetComponent<TextMeshProUGUI>().text = player2Score.ToString();
        ResetPosition();
    }

    private void ResetPosition()
    {
        GameObject.Find("Ball").GetComponent<Ball>().Reset();
        GameObject.Find("Player 1").GetComponent<Puddle>().Reset();
        GameObject.Find("Player 2").GetComponent<Puddle>().Reset();
    }

    public void ResumeOrPauseGame()
    {
        if (isPaused)
        {
            GameManger.ResumeGameStatic();
        }
        else
        {
            GameManger.PauseGameStatic();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public static void ResumeGameStatic()
    {
        sharedInstance.isPaused = false;
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    }

    public static void PauseGameStatic()
    {
        sharedInstance.isPaused = true;
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }
}
