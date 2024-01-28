using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public GameSettings GameSettings;
    public int GameScore { get; private set; }
    public bool IsHighScoreReached { get; private set; }
    
    public Action OnGameStarted,OnGameOver;
    public Action<int> OnScoreChanged;
    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void FinishGame()
    {
        CheckHighScore();
        OnGameOver?.Invoke();
    }

    public void IncreaseScore(int increaseAmount =1)
    {
        GameScore += increaseAmount;
        OnScoreChanged?.Invoke(GameScore);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void CheckHighScore()
    {
        if (GameScore > SaveData.HighScore)
        {
            SaveData.HighScore = GameScore;
            IsHighScoreReached = true;
        }
    }
    
}
