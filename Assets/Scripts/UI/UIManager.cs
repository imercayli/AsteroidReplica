using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public StartCanvas StartCanvas;
    public CurrencyCanvas CurrencyCanvas;
    public GamePlayCanvas GamePlayCanvas;
    public GameOverCanvas GameOverCanvas;
    
    void Start()
    {
        GamePlayCanvas.gameObject.SetActive(false);
        GameOverCanvas.gameObject.SetActive(false);
        GameManager.Instance.OnGameStarted += OnGameStarted;
        GameManager.Instance.OnGameOver += OnGameFinished;
    }

    private void OnGameStarted()
    {
        StartCanvas.gameObject.SetActive(false);
        GamePlayCanvas.gameObject.SetActive(true);
    }
    private void OnGameFinished()
    {
        GamePlayCanvas.gameObject.SetActive(false);
        GameOverCanvas.gameObject.SetActive(true);
    }
    
}
