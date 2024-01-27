using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private GameObject healthIconTemplate;
     private List<GameObject> healthIcons = new List<GameObject>();
     [SerializeField] private Button shootButton;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayerHealthIcons();
        Player.Instance.PlayerHealth.OnPlayerHealthChanged += OnPlayerHealthChanged;
        GameManager.Instance.OnScoreChanged += OnScoreChanged;
        shootButton.onClick.AddListener(OnShootButtonTap);
    }

    private void SpawnPlayerHealthIcons()
    {
        for (int i = 0; i < Player.Instance.PlayerHealth.MaxHealth; i++)
        {
            GameObject healthIcon = Instantiate(healthIconTemplate, healthIconTemplate.transform.parent);
            healthIcons.Add(healthIcon);
        }
        
        Destroy(healthIconTemplate);
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

    private void OnShootButtonTap()
    {
        Player.Instance.PlayerAttack.Shoot();
    }

}
