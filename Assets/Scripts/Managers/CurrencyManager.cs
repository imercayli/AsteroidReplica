using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoSingleton<CurrencyManager>
{
    private List<CurrencyData> currencyDatas;
    public UnityAction OnAllCurrenciesUpdate;

    public List<CurrencyData> GetAllCurrencyDatas => currencyDatas;

    public CurrencyData GetCurrencyData(CurrencyType currencyType)
    {
        return currencyDatas.Find(o => o.CurrencyType == currencyType);
    }

    protected override void Awake()
    {
        base.Awake();
        currencyDatas = Resources.LoadAll<CurrencyData>("Currencies").ToList();
        SubscribeAllCurrencyUpdateEvents();
    }


    private void SubscribeAllCurrencyUpdateEvents()
    {
        foreach (var currencyData in currencyDatas)
        {
            currencyData.OnCurrencyUpdate += AllCurrenciesUpgrade;
        }
    }

    private void AllCurrenciesUpgrade()
    {
        OnAllCurrenciesUpdate?.Invoke();
    }

    public void UnsubscribeAllCurrencyUpdateEvents()
    {
        foreach (var currencyData in currencyDatas)
        {
            currencyData.OnCurrencyUpdate -= AllCurrenciesUpgrade;
        }
    }

    private void OnDestroy()
    {
        UnsubscribeAllCurrencyUpdateEvents();
    }
}