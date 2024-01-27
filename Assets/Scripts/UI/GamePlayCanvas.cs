using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private GameObject healthIconTemplate;
     private List<GameObject> healthIcons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayerHealthIcons();
        Player.Instance.PlayerHealth.OnPlayerHealthChanged += OnPlayerHealthChanged;
        GameManager.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void SpawnPlayerHealthIcons()
    {
        for (int i = 0; i < Player.Instance.PlayerHealth.MaxHealth; i++)
        {
            GameObject healthIcon = Instantiate(healthIconTemplate, healthIconTemplate.transform.parent);
            healthIcons.Add(healthIcon);
        }
    }

    private void OnPlayerHealthChanged(int health)
    {
        for (int i = 0; i < healthIcons.Count; i++)
        {
            healthIcons[i].SetActive(i<health);
        }
    }

    private void OnScoreChanged(int score)
    {
        gameScoreText.text = $"{score}";
    }

}
