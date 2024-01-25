using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerSkin Type", menuName = "Scriptable Objects/CustomizationData/PlayerSkin")]
public class PlayerSkinCustomizationData : CustomizationDataBase
{
    public override CustomizationType CustomizationType => CustomizationType.PlayerSkin;
    protected override bool IsDefault => SaveData.PlayerSkinDefaultId == Id;
    public override bool IsCurrentItem()
    {
        return Id == SaveData.CurrentPlayerSkinId;
    }
    
    protected override void SetId()
    {
        SaveData.CurrentPlayerSkinId = Id;
    }
}
