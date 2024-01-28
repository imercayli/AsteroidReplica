using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPoolingManager : MonoSingleton<ObjectPoolingManager>
{
    [SerializeField] private  LevelObjectInteractParticle levelObjectInteractParticlePrefab;
    public ObjectPooling<LevelObjectInteractParticle> LevelObjectInteractParticleObjectPooling;
    
    [SerializeField] private  KillParticle killParticlePrefab;
    public ObjectPooling<KillParticle> KillParticleObjectPooling;

    protected override void Awake()
    {
        base.Awake();
        CreatePools();
    }

    private void CreatePools()
    {
        LevelObjectInteractParticleObjectPooling =
            new ObjectPooling<LevelObjectInteractParticle>(levelObjectInteractParticlePrefab, transform);
        
        KillParticleObjectPooling =
            new ObjectPooling<KillParticle>(killParticlePrefab, transform,30);
        
    }

    public T InstantiatePoolObject<T>(T prefab, Transform parent) where T : MonoBehaviour
    {
        var obj = Instantiate(prefab, parent);
        return obj;
    }


}