using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomizationDataBase : ScriptableObject
{
    public abstract CustomizationType CustomizationType { get; } 
    protected abstract bool IsDefault  { get; }
    [Header("Unlock Proporties")]
    public int Id;
    public CurrencyData UnlockCurrencyData;
    public int UnlockLevelAmount;

    [Header("UI Attributes")]
    public Sprite UIImage;
    
    private string customizationItemUnlockKey = "customizationItemUnlockKey";
    public bool IsUnlock
    {
        get => IsDefault ? true : PlayerPrefs.GetInt(customizationItemUnlockKey + Id + CustomizationType.ToString(), 0) == 1; 
        protected set => PlayerPrefs.SetInt(customizationItemUnlockKey + Id + CustomizationType.ToString(), value ? 1 : 0);
    }

    public abstract bool IsCurrentItem();

    public void SelectItem()
    {
       SetId();
       UnlockCurrencyData.OnCurrencyUpdate?.Invoke();
    }

    public void UnlockItem()
    {
        IsUnlock = true;
        SetId();
        UnlockCurrencyData.SetAmount(-UnlockLevelAmount);
    }

    protected abstract void SetId();

    public bool CanAfford()
    {
        return !IsUnlock && UnlockCurrencyData.CurrencyAmount >= UnlockLevelAmount;
    }
}
