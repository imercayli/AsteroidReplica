using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationCanvas : MonoBehaviour
{
    [SerializeField] private Button shopButton;
    
    [SerializeField] private GameObject shopMenu, exclamation;
    
    // Start is called before the first frame update
    void Start()
    {
        shopMenu.SetActive(false);
        shopButton.onClick.AddListener(OnShopButtonTap);
        shopMenu.SetActive(false);
        SetExclamation();
        CurrencyManager.Instance.OnAllCurrenciesUpdate += SetExclamation;

    }

    private void SetExclamation()
    {
        bool canAffortAnyItem = CustomizationManager.Instance.CustomizationDataBases.FindAll(o => o.CanAfford()).Count > 0;
        exclamation.SetActive(canAffortAnyItem);
    }

    private void OnShopButtonTap()
    {
        shopMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        CurrencyManager.Instance.OnAllCurrenciesUpdate -= SetExclamation;
    }
}
