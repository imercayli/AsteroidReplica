using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CustomizationMenu : MonoBehaviour
{
    [SerializeField] private CustomizationItemButton customizationItemButtonTemplate;
    private List<CustomizationItemButton> customizationItemButtons = new List<CustomizationItemButton>();
    [SerializeField]  private Transform contentParentPlayerSkins,contentParentBullets;
    [SerializeField] private Button closeButton;
    
    void Start()
    {
        closeButton.onClick.AddListener(OnCloseButtonTap);
        SpawnItemButtons();
    }

    private void OnEnable()
    {
        AnimateButtons();
    }

    private void SpawnItemButtons()
    {
        // foreach (var tubeDatas in CustomizationManager.Instance.CustomizationDataBases.FindAll(o=>o.CustomizationType==CustomizationType.PlayerSkin)
        //              .OrderBy(o => o.Id))
        // {
        //     var button = Instantiate(customizationItemButtonTemplate, contentParentPlayerSkins);
        //     button.Initialize(tubeDatas);
        //     button.transform.localScale = Vector3.zero;
        //     shopItemButtons.Add(button);
        //
        // }
    }
    
    private void AnimateButtons()
    {
        // StartCoroutine(Routine());
        // IEnumerator Routine()
        // {
        //     shopItemButtons.ForEach(o => o.transform.localScale = Vector3.zero);
        //     yield return null;
        //     float time = .075f;
        //     foreach (var button in shopItemButtons)
        //     {
        //         button.transform.DOScale(1f, time);
        //         yield return new WaitForSeconds(time);
        //     }
        // }
    }

    private void OnCloseButtonTap()
    {
        gameObject.SetActive(false);
    }
}
