using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpawner : MonoBehaviour
{
    public GameObject coin, diamond;

    public float minTime, maxTime;

    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCurrencyObject()
    {
        if(Time.time<spawnTimer) return;
        
        //spawnTimer = ti
    }
}
