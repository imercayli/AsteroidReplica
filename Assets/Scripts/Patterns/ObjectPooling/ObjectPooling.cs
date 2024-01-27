using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectPooling<T> where T : MonoBehaviour
{
    private T objectPrefab;
    private List<T> objectPoolList = new List<T>();
    private Transform parent;
    private int initialSpawnAmount;

    public ObjectPooling(T objectPrefab,Transform parent, int initialSpawnAmount = 10)
    {
        this.objectPrefab = objectPrefab;
        this.parent = parent;
        this.initialSpawnAmount = initialSpawnAmount;
        
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < initialSpawnAmount; i++)
        {
            var obj = ObjectPoolingManager.Instance.InstantiatePoolObject(objectPrefab, parent);
            obj.gameObject.SetActive(false);
            objectPoolList.Add(obj);
        }
    }

    public void AddObjectToPool(T obj)
    {
        if (objectPoolList.Contains(obj)) return;
    
        obj.gameObject.SetActive(false);
        objectPoolList.Add(obj);
    }

    public T GetObjectFromPool()
    {
        if (objectPoolList.Count == 0)
        {
            CreatePool();

        }

        var obj = objectPoolList[0];
        objectPoolList.Remove(obj);
        obj.gameObject.SetActive(true);
        return obj;
    }

}
