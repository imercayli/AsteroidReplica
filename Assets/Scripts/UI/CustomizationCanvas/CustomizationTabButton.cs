using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Extentions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationTabButton : MonoBehaviour
{
    public CustomizationType CustomizationType { get; private set; }
    private CustomizationMenu _customizationMenu;
    [SerializeField] private Color selectedColor, deselectedColor;
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI titleText;

    public void Initialize(CustomizationType customizationType,CustomizationMenu customizationMenu)
    {
        CustomizationType = customizationType;
        _customizationMenu = customizationMenu;
        button.onClick.AddListener(OnButtonTap);
        titleText.text = customizationType.ToString().TitleCase();
    }

    private void OnButtonTap()
    {
        _customizationMenu.OnTabButtonTap(CustomizationType);
    }

    public void Select()
    {
        button.interactable = false;
        image.color = selectedColor;
    }

    public void Deselect()
    {
        button.interactable = true;
        image.color = deselectedColor;
    }
}
