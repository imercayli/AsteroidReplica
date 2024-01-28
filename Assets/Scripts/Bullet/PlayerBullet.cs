using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBullet : BulletBase
{
    public List<PlayerBulletSkin> PlayerBulletSkins { get; private set; }
    public override void Initialize(AttackBase attackBase)
    {
        base.Initialize(attackBase);
        
        PlayerBulletSkins = GetComponentsInChildren<PlayerBulletSkin>(true).ToList();
        SetCurrentSkin();
        SaveData.OnPlayerSkinChanged += SetCurrentSkin; 
    }
    
    private void SetCurrentSkin()
    {
        PlayerBulletSkins.ForEach(o=>o.gameObject.SetActive(false));
        PlayerBulletSkin PlayerBulletSkin = PlayerBulletSkins.Find(o => o.Id == SaveData.CurrentBulletId);
        PlayerBulletSkin.gameObject.SetActive(true);
    }

    protected override bool Check(HealthBase healthBase)
    {
        return healthBase.CharacterType != CharacterType.Player;
    }
}
