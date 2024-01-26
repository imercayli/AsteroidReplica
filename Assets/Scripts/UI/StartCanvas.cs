using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCanvas : MonoBehaviour
{
    [SerializeField] private Button startButton;
    
    
    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonTap);
    }

    private void OnStartButtonTap()
    {
        GameManager.Instance.StartGame();
    }
}
