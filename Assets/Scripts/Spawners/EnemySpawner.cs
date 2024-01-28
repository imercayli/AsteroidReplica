using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemySpawner : SpawnerBase
{
    protected override float delayTime => GameManager.Instance.GameSettings.GetEnemySpawnDelay();
    [SerializeField] private List<Asteroid> asteroidPrefabs;
    private List<ObjectPooling<Asteroid>> asteroidsObjectPoolings = new List<ObjectPooling<Asteroid>>();
    [SerializeField] private Ufo ufoPrefab;
    private ObjectPooling<Ufo> ufObjectPooling;
    [SerializeField] private float outerBoxOffset = 2f;
    
    protected override void CreateObjectPoolings()
    {
        foreach (Asteroid asteroidPrefab in asteroidPrefabs)
        {
            ObjectPooling<Asteroid> objectPooling = new ObjectPooling<Asteroid>(asteroidPrefab, transform);
            asteroidsObjectPoolings.Add(objectPooling);
        }

        ufObjectPooling = new ObjectPooling<Ufo>(ufoPrefab, transform);
    }
    
    protected override void SpawnObject()
    {
        bool canUfoSpawn =GameManager.Instance.GameScore >= GameManager.Instance.GameSettings.UfoEnemyStartScore 
                          &&  GameManager.Instance.GameSettings.GetUfoSpawnChance() > Random.Range(0f, 1f);

        if (canUfoSpawn)
        {
            Ufo ufo = ufObjectPooling.GetObjectFromPool();
            ufo.transform.position = GetSpawnPosition();
            ufo.EnemySpawned(this);
        }
        else
        {
            Asteroid asteroid = asteroidsObjectPoolings[0].GetObjectFromPool();
            asteroid.transform.position = GetSpawnPosition();
            asteroid.EnemySpawned(this);
        }
    }
    
    public void OnAstreoidKilled(Asteroid asteroid,bool isDead)
    {
        asteroidsObjectPoolings[asteroid.Level-1].AddObjectToPool(asteroid);
        
        if(!isDead) return;
        int newAsteroidLevel = asteroid.Level + 1;
        if(newAsteroidLevel > asteroidsObjectPoolings.Count) return;

        int spawnCount = 2;
        for (int i = 0; i < spawnCount; i++)
        {
            Asteroid newAsteroid = asteroidsObjectPoolings[newAsteroidLevel-1].GetObjectFromPool();
            newAsteroid.transform.position = asteroid.transform.position;
            newAsteroid.EnemySpawned(this);
        }
    }

    public void OnUfoKilled(Ufo ufo,bool isDead)
    {
        ufObjectPooling.AddObjectToPool(ufo);
    }
    
    protected override Vector2 GetSpawnPosition()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(screenSize.x, screenSize.y));

        Rect innerBox = new Rect(-screenBounds.x, -screenBounds.y, screenBounds.x * 2, screenBounds.y * 2);
        Rect outerBox = new Rect(innerBox.xMin - outerBoxOffset, innerBox.yMin - outerBoxOffset, innerBox.width + outerBoxOffset * 2, innerBox.height + outerBoxOffset * 2);

        Vector2 spawnPosition;
        do
        {
            float x = Random.Range(outerBox.xMin, outerBox.xMax);
            float y = Random.Range(outerBox.yMin, outerBox.yMax);
            spawnPosition = new Vector2(x, y);
        } 
        while (innerBox.Contains(spawnPosition));

        return spawnPosition;
    }
}

