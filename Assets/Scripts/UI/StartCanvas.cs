using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Button startButton;
    
    
    void Start()
    {
        SetUI();
        startButton.onClick.AddListener(OnStartButtonTap);
    }

    private void SetUI()
    {
        highScoreText.text = $"High Score : {SaveData.HighScore}";
    }

    private void OnStartButtonTap()
    {
        GameManager.Instance.StartGame();
    }
}
