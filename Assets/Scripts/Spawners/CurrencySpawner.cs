using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpawner : MonoBehaviour
{
    private Dictionary<CurrencyType,ObjectPooling<CurrencyLevelObjectBase>> _currencyTypesObjectPooling = new();
    [SerializeField] private float minTime, maxTime;
    private float spawnTimer;
    
    private Camera mainCamera;
    private bool isGameStarted;
    // Start is called before the first frame update
    void Start()
    { 
        mainCamera = Camera.main;
        GameManager.Instance.OnGameStarted += () => isGameStarted = true;
        GameManager.Instance.OnGameOver += () => isGameStarted = false;
       CreateObjectPoolings();   
    }

    void Update()
    {
        SpawnCurrencyObject();
    }
    
    private void CreateObjectPoolings()
    {
        foreach (CurrencyData currencyData in CurrencyManager.Instance.GetAllCurrencyDatas)
        {
            ObjectPooling<CurrencyLevelObjectBase> objectPooling =
                new ObjectPooling<CurrencyLevelObjectBase>(currencyData.CurrencyLevelObjectBase, transform);
            
            _currencyTypesObjectPooling.Add(currencyData.CurrencyType,objectPooling);
        }
    }

    private void SpawnCurrencyObject()
    {
        if(!isGameStarted) return;
        if(Time.time<spawnTimer) return;

        spawnTimer = Time.time + Random.Range(minTime, maxTime);
        
        int enumLenght = System.Enum.GetValues(typeof(CurrencyType)).Length;
        CurrencyType selectedCurrenyType = (CurrencyType)FormulaExtentions.Formulas.GetRandomEnumByCoefficient(enumLenght);
        CurrencyLevelObjectBase currencyLevelObjectBase = _currencyTypesObjectPooling[selectedCurrenyType].GetObjectFromPool();
        currencyLevelObjectBase.transform.position = GetSpawnPosition();
        currencyLevelObjectBase.Initialize(this);
    }

    public void AddToPool(CurrencyLevelObjectBase currencyLevelObjectBase)
    {
        _currencyTypesObjectPooling[currencyLevelObjectBase.CurrencyType].AddObjectToPool(currencyLevelObjectBase);
    }
    
    private Vector2 GetSpawnPosition()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector2(screenSize.x, screenSize.y));

        Rect innerBox = new Rect(-screenBounds.x, -screenBounds.y, screenBounds.x * 2, screenBounds.y * 2);
        float x = Random.Range(innerBox.xMin, innerBox.xMax);
        float y = Random.Range(innerBox.yMin, innerBox.yMax);
        Vector2 spawnPosition = new Vector2(x, y);

        return spawnPosition;
    }
}
