using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPoolingManager : MonoSingleton<ObjectPoolingManager>
{

    public T InstantiatePoolObject<T>(T prefab, Transform parent) where T : MonoBehaviour
    {
        var obj = Instantiate(prefab, parent);
        return obj;
    }


}