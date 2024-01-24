using UnityEngine;

public static class SaveData
{
    public static int HighScore
    {
        get => PlayerPrefs.GetInt(GameDataKeys.HighScoreKey, 0);
        set => PlayerPrefs.SetInt(GameDataKeys.HighScoreKey, value);
    }

    public struct GameDataKeys
    {
        public const string HighScoreKey = "HighScoreKey";
    }

}
