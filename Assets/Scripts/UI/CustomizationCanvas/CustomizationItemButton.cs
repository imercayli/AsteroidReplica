using System;
using System.Collections;
using System.Collections.Generic;
using Extentions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationItemButton : MonoBehaviour
{
    private CustomizationDataBase _customizationDataBase;
    [SerializeField] private Image itemImage;
    [SerializeField] private GameObject currentFrame, unlockGroup, lockGroup;
    [SerializeField ]private TextMeshProUGUI unlockCurrenyAmount;
    [SerializeField] private Button selectButton, unlockButton;
    [SerializeField] private GameObject selectedImage;
    [SerializeField] private Image currencyIconImage;
    
    public void Initialize(CustomizationDataBase customizationDataBase)
    {
        _customizationDataBase = customizationDataBase;
        SetUI();
        SetButtonListeners();
    }

    private void OnEnable()
    {
        if(!_customizationDataBase) return;
        
        CurrencyManager.Instance.OnAllCurrenciesUpdate += SetUI;
    }
    
    private void SetUI()
    {
        itemImage.sprite = _customizationDataBase.UIImage;
        currencyIconImage.sprite = _customizationDataBase.UnlockCurrencyData.CurrencyIcon;

        unlockGroup.SetActive(_customizationDataBase.IsUnlock);
        lockGroup.SetActive(!_customizationDataBase.IsUnlock);

        if (_customizationDataBase.IsUnlock)
        {
            bool isCurrentItem = _customizationDataBase.IsCurrentItem();

            currentFrame.SetActive(isCurrentItem);
            selectButton.gameObject.SetActive(!isCurrentItem);
            selectedImage.SetActive(isCurrentItem);

        }
        else
        {
            currentFrame.SetActive(false);

            bool isCurrencyEnough = _customizationDataBase.CanAfford();
            
            unlockButton.interactable = isCurrencyEnough;
            unlockCurrenyAmount.text = _customizationDataBase.UnlockLevelAmount.LargeIntToString();

        }
    }

    private void SetButtonListeners()
    {
        selectButton.onClick.AddListener(OnSelectButtonTap);
        unlockButton.onClick.AddListener(OnUnlockButtonTap);
    }

    private void OnSelectButtonTap()
    {
        _customizationDataBase.SelectItem();
    }

    private void OnUnlockButtonTap()
    {
       _customizationDataBase.UnlockItem();
    }
    
    private void OnDisable()
    {
        if(!_customizationDataBase) return;
        CurrencyManager.Instance.OnAllCurrenciesUpdate -= SetUI;
    }

}
