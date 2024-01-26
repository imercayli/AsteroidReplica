using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject newHighScoreText;
    [SerializeField] private Button restartButton;
   
    void Start()
    {
        SetUI();
        restartButton.onClick.AddListener(OnRestartButtonTap);
    }

    private void SetUI()
    {
        newHighScoreText.SetActive(false); 
        float score=0;
        DOTween.To(() => 0, x => score = x, GameManager.Instance.GameScore, .5f)
            .OnUpdate(() =>
            {
                scoreText.text = $"Score : {score}";
            }).OnComplete((() =>
            {
                if (GameManager.Instance.IsHighScoreReached)
                {
                    newHighScoreText.SetActive(true); 
                    newHighScoreText.transform.DOScale(1, 0.5f).From(0);
                }
                   
            }));
    }

    private void OnRestartButtonTap()
    {
        GameManager.Instance.ReloadScene();
    }

}
