using System;
using UnityEngine;

public static class SaveData
{
    public static int HighScore
    {
        get => PlayerPrefs.GetInt(SaveDataKeys.HighScore, 0);
        set => PlayerPrefs.SetInt(SaveDataKeys.HighScore, value);
    }

    public static Action OnPlayerSkinChanged;
    public static int PlayerSkinDefaultId = 1;
    public static int CurrentPlayerSkinId
    {
        get => PlayerPrefs.GetInt(SaveDataKeys.CurrentPlayerSkinId, PlayerSkinDefaultId);
        set
        {
            PlayerPrefs.SetInt(SaveDataKeys.CurrentPlayerSkinId, value);
            OnPlayerSkinChanged?.Invoke();
        }
    }
    
    public static Action OnBulletChanged;
    public static int BulletDefaultId = 1;
    public static int CurrentBulletId
    {
        get => PlayerPrefs.GetInt(SaveDataKeys.CurrentBulletId, BulletDefaultId);
        set
        {
            PlayerPrefs.SetInt(SaveDataKeys.CurrentBulletId, value);
            OnBulletChanged?.Invoke();
        }
    }

    public struct SaveDataKeys
    {
        public const string HighScore = "HighScore"; 
        public const string CurrentPlayerSkinId = "CurrentPlayerSkinId";
        public const string CurrentBulletId = "CurrentBulletId";
    }

}
