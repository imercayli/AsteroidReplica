using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Currency Type", menuName = "Scriptable Objects/Currency")]
public class CurrencyData : ScriptableObject
{
    public string CurrencyName;
    public CurrencyType CurrencyType;
    public long DefaultAmount;

    [Header("Level Object")] 
    public CurrencyLevelObjectBase CurrencyLevelObjectBase;
    
    [Space(10)]
    [Header("UI")]
    public Sprite CurrencyIcon;

    public Action OnCurrencyUpdate;
    public long CurrencyAmount
    {
        get => long.Parse(PlayerPrefs.GetString(CurrencyName, DefaultAmount.ToString()));
        private set
        {
            PlayerPrefs.SetString(CurrencyName, value.ToString());
            OnCurrencyUpdate?.Invoke();
        }
    }

    public void SetAmount(long amount=1)
    {
        CurrencyAmount += amount;
    }

}
