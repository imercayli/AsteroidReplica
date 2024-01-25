using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Type", menuName = "Scriptable Objects/CustomizationData/Bullet")]
public class BulletCustomizationData : CustomizationDataBase
{
    public override CustomizationType CustomizationType => CustomizationType.Bullet;
    protected override bool IsDefault => SaveData.BulletDefaultId == Id;

    public override bool IsCurrentItem()
    {
        return Id == SaveData.CurrentBulletId;
    }

    protected override void SetId()
    {
        SaveData.CurrentBulletId = Id;
    }
}
