using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCanvas : MonoBehaviour
{
    [SerializeField] private CurrencyItemUI currencyItemUITemplate;
    
    void Start()
    {
        SpawnCurrencyItemUIs();
    }

    private void SpawnCurrencyItemUIs()
    {
        foreach (CurrencyData currencyData in CurrencyManager.Instance.GetAllCurrencyDatas)
        {
            CurrencyItemUI currencyItemUI =
                Instantiate(currencyItemUITemplate, currencyItemUITemplate.transform.parent);
            currencyItemUI.Initialize(currencyData);
        }
        
        Destroy(currencyItemUITemplate.gameObject);
    }
}
