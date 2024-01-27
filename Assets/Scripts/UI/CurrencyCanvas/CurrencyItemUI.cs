using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Extentions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyItemUI : MonoBehaviour
{
    private CurrencyData _currencyData;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI amountText;

    public void Initialize(CurrencyData currencyData)
    {
        _currencyData = currencyData;
        icon.sprite = _currencyData.CurrencyIcon;
        _currencyData.OnCurrencyUpdate += (delegate { SetCurrencyAmount(true); });
        SetCurrencyAmount(false);
        
    }

    private void SetCurrencyAmount(bool withAnim)
    {
        amountText.text = $"{_currencyData.CurrencyAmount.LargeLongToString()}";
        
        if(withAnim)
            amountText.transform.DOPunchScale(Vector3.one * 0.25f, 0.25f);
    }
}
