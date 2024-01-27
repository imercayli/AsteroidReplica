using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationCanvas : MonoBehaviour
{
    [SerializeField] private Button customizationButton;
    
    [SerializeField] private GameObject customizationMenu, exclamation;
    
    // Start is called before the first frame update
    void Start()
    {
        customizationMenu.SetActive(false);
        customizationButton.onClick.AddListener(OnShopButtonTap);
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
        customizationMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        CurrencyManager.Instance.OnAllCurrenciesUpdate -= SetExclamation;
    }
}
