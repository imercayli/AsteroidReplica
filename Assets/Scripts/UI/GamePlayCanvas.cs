using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private List<GameObject> healthIcons;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        gameScoreText.text = $"{score}";
    }

}
