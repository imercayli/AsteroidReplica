using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Extentions;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CustomizationMenu : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private CustomizationTabButton customizationTabButtonTemplate;
    [SerializeField] private CustomizationPanel customizationPanelTemplate;
    private List<CustomizationPanel> _customizationPanels = new List<CustomizationPanel>();
    private List<CustomizationTabButton> _customizationTabButtons = new List<CustomizationTabButton>();
    private CustomizationTabButton currentTabButton;
    [SerializeField] private HorizontalLayoutGroup tabButtonHorizontalLayoutGroup;
    [SerializeField] private float horizontalMinSpace, horizontalMaxSpace;

    public void Initialize()
    {
        closeButton.onClick.AddListener(OnCloseButtonTap);
        SpawnPanelAndTabButtons();
       
    }

    private void SpawnPanelAndTabButtons()
    {
        int customizationTypeCount = System.Enum.GetValues(typeof(CustomizationType)).Length;
       
        for (int i = 0; i < customizationTypeCount; i++)
        {
            int index = i;
            CustomizationPanel customizationPanel =
                Instantiate(customizationPanelTemplate, customizationPanelTemplate.transform.parent);
            customizationPanel.Initialize((CustomizationType)index);
            _customizationPanels.Add(customizationPanel);

            CustomizationTabButton tabButton = Instantiate(customizationTabButtonTemplate,
                customizationTabButtonTemplate.transform.parent);
            tabButton.Initialize((CustomizationType)index,this);
            _customizationTabButtons.Add(tabButton);
        }
        
        Destroy(customizationPanelTemplate.gameObject);
        Destroy(customizationTabButtonTemplate.gameObject);

        tabButtonHorizontalLayoutGroup.spacing = Mathf.Lerp(horizontalMinSpace, horizontalMaxSpace,
            Mathf.InverseLerp(2, 6, _customizationTabButtons.Count));
        
        SetActivation(CustomizationType.PlayerSkin);
    }

    public void OnTabButtonTap(CustomizationType customizationType)
    {
       SetActivation(customizationType);
    }

    private void SetActivation(CustomizationType customizationType)
    {
        _customizationPanels.ForEach(o=>o.gameObject.SetActive(false));
        _customizationPanels.Find(o => o.CustomizationType == customizationType).gameObject.SetActive(true);
        
        if(currentTabButton)
            currentTabButton.Deselect();
        currentTabButton = _customizationTabButtons.Find(o => o.CustomizationType == customizationType);
        currentTabButton.Select();
    }

    private void OnCloseButtonTap()
    {
        gameObject.SetActive(false);
    }
}
