using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
  [Header("Scores For Settings")] 
  [SerializeField] private int minScoreForSettings;
  [SerializeField] private int maxScoreForSettings;
  public float ScoreT
    => Mathf.InverseLerp(minScoreForSettings, maxScoreForSettings, GameManager.Instance.GameScore);

  [Header("Enemy Speed")] 
  [SerializeField] private float enemySpeedMin;
  [SerializeField] private float enemySpeedMax;
  public float GetEnemySpeed() => Mathf.Lerp(enemySpeedMin, enemySpeedMax, ScoreT);

  [Header("Enemy Spawn")] 
  [SerializeField] private float enemySpawnDelayMin;
  [SerializeField] private float enemySpawnDelayMax;
  public float GetEnemySpawnDelay() => Mathf.Lerp(enemySpawnDelayMin, enemySpawnDelayMax, ScoreT);
  [SerializeField] private float ufoEnemyStartScore;
  public float GetUfoEnemyStartTime => ufoEnemyStartScore;
  
  [Header("Currency Spawn")]
  [SerializeField] private float currencySpawnDelayMin;
  [SerializeField] private float currencySpawnDelayMax;
  public float GetCurrencySpawnDelay() => Mathf.Lerp(currencySpawnDelayMin, currencySpawnDelayMax, ScoreT);

}
