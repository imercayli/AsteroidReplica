using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectInteractParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    
    public void Initialize(Color color)
    {
        _particleSystem.startColor = color;

        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            yield return new WaitForSeconds(_particleSystem.main.duration);
            ObjectPoolingManager.Instance.LevelObjectInteractParticleObjectPooling.AddObjectToPool(this);
        }
    }
}
