using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class CustomizationPanel : MonoBehaviour
{
    public CustomizationType CustomizationType { get; private set; }
    [SerializeField] private CustomizationItemButton customizationItemButtonTemplate;
    private List<CustomizationItemButton> customizationItemButtons = new List<CustomizationItemButton>();

    public void Initialize(CustomizationType customizationType)
    {
        CustomizationType = customizationType;
        SpawnItemButtons();
    }

    private void OnEnable()
    {
        AnimateButtons();
    }

    private void SpawnItemButtons()
    {
        foreach (CustomizationDataBase customizationDataBase in CustomizationManager.Instance.CustomizationDataBases
                     .FindAll(o=>o.CustomizationType==CustomizationType)
                     .OrderBy(o => o.Id))
        {
            CustomizationItemButton customizationItemButton = Instantiate(customizationItemButtonTemplate, customizationItemButtonTemplate.transform.parent);
            customizationItemButton.Initialize(customizationDataBase);
            customizationItemButtons.Add(customizationItemButton);
        
        }
        
        Destroy(customizationItemButtonTemplate.gameObject);
    }
    
    private void AnimateButtons()
    {
        StartCoroutine(Routine());
        IEnumerator Routine()
        {
            customizationItemButtons.ForEach(o => o.transform.localScale = Vector3.zero);
            yield return null;
            float time = .075f;
            foreach (var button in customizationItemButtons)
            {
                button.transform.DOScale(1f, time);
                yield return new WaitForSeconds(time);
            }
        }
    }
}
