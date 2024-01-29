using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerAttack PlayerAttack { get; private set; }
    public PlayerHealth PlayerHealth { get; private set; }
    public PlayerInteraction PlayerInteraction { get; private set; }
    public List<PlayerSkin> PlayerSkins { get; private set; }
    public PlayerSkin CurrentSkin { get; private set; }

    public Action OnSkinChange;

    public Action OnDied;
    public Action<float> OnReborn;
 
    protected override void Awake()
    {
        base.Awake();
        PlayerSkins = GetComponentsInChildren<PlayerSkin>(true).ToList();
        SetCurrentSkin();
        SaveData.OnPlayerSkinChanged += SetCurrentSkin; 
        
        PlayerMovement = GetComponent<PlayerMovement>().Initialize(this);
        PlayerAttack = GetComponent<PlayerAttack>().Initialize(this);
        PlayerHealth = GetComponent<PlayerHealth>().Initialize(this);
        PlayerInteraction = GetComponent<PlayerInteraction>().Initialize(this);
    }
    
    private void SetCurrentSkin()
    {
        PlayerSkins.ForEach(o=>o.gameObject.SetActive(false));
        CurrentSkin = PlayerSkins.Find(o => o.Id == SaveData.CurrentPlayerSkinId);
        CurrentSkin.gameObject.SetActive(true);
        OnSkinChange?.Invoke();
    }

    public void Die()
    {
        GameManager.Instance.FinishGame();
        OnDied?.Invoke();
        gameObject.SetActive(false);
    }

    public void Reborn()
    {
        float rebornTime = 3f;
        OnReborn?.Invoke(rebornTime);
        CurrentSkin.Reborn(rebornTime);
    }

    private void OnDestroy()
    {
         SaveData.OnPlayerSkinChanged -= SetCurrentSkin; 
    }
}
