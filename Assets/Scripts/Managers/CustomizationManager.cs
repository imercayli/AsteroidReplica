using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomizationManager : MonoSingleton<CustomizationManager>
{
    public List<CustomizationDataBase> CustomizationDataBases { get; private set; }
    protected override void Awake()
    {
        base.Awake();

        CustomizationDataBases = Resources.LoadAll<CustomizationDataBase>("CustomizationDatas").ToList();
    }
}
