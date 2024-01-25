using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBullet : BulletBase
{
    public List<PlayerBulletSkin> PlayerBulletSkins { get; private set; }
    public override void Initialize(AttackSystemBase attackSystemBase)
    {
        base.Initialize(attackSystemBase);
        
        PlayerBulletSkins = GetComponentsInChildren<PlayerBulletSkin>().ToList();
        SetCurrentSkin();
        SaveData.OnPlayerSkinChanged += SetCurrentSkin; 
    }
    
    private void SetCurrentSkin()
    {
        PlayerBulletSkins.ForEach(o=>o.gameObject.SetActive(false));
        PlayerBulletSkin PlayerBulletSkin = PlayerBulletSkins.Find(o => o.Id == SaveData.CurrentBulletId);
        PlayerBulletSkin.gameObject.SetActive(true);
    }

    protected override bool Check(GameObject gameObject)
    {
        return gameObject.GetComponent<HealthSystemBase>().CharacterType != CharacterType.Player;
    }
}
