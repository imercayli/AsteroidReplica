using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SpawnerBase : MonoBehaviour
{
    protected Camera mainCamera;
    protected bool isGameStarted;
    protected float spawnTimer;
    
    protected abstract float delayTime { get; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        mainCamera = Camera.main;
        GameManager.Instance.OnGameStarted += () => isGameStarted = true;
        GameManager.Instance.OnGameOver += () => isGameStarted = false;
        CreateObjectPoolings();   
    }
    
    protected virtual void Update()
    {
        if(!isGameStarted) return;
        if(Time.time<spawnTimer) return;
    
        spawnTimer = Time.time + delayTime;
        
        SpawnObject();
    }
    
    protected abstract void CreateObjectPoolings();
    protected abstract void SpawnObject();
    protected abstract Vector2 GetSpawnPosition();

}
