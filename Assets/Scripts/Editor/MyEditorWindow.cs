using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum EditorWindowType
{
    AddCurrency,
    IncreaseLevel
}

public class MyEditorWindow : EditorWindow
{
    private static EditorWindowType editorWindowType;
    private CurrencyType currencyType;
    private static int increaseCurrencyValue = 100;
    private static int increaseScoreValue = 1;

    [MenuItem("My Editor Window/Add Currency", false, 1)]
    private static void AddCurrency()
    {
        editorWindowType = EditorWindowType.AddCurrency;
        EditorWindow window = GetWindow(typeof(MyEditorWindow));
        window.Show();
    }

    [MenuItem("My Editor Window/Increase Level", false, 1)]
    private static void SetLevel()
    {
       editorWindowType = EditorWindowType.IncreaseLevel;
       EditorWindow window = GetWindow(typeof(MyEditorWindow));
       window.Show();
    }

    void OnGUI()
    {
        switch (editorWindowType)
        {
            case EditorWindowType.AddCurrency:
                AddCurrencyWindow();
                break;
            case EditorWindowType.IncreaseLevel:
                IncreaseScoreWindow();
                break;
            default:
                break;
        }

    }

    private void AddCurrencyWindow()
    {
        currencyType = (CurrencyType)EditorGUILayout.EnumPopup("Currency:", currencyType);
        increaseCurrencyValue = EditorGUILayout.IntField("Enter the value", increaseCurrencyValue);
        if (GUILayout.Button("Add!"))
        {
            var currencyDatas = new List<CurrencyData>(Resources.LoadAll<CurrencyData>("Currencies"));
            var currency = currencyDatas.Find(o => o.CurrencyType == currencyType);
            currency.SetAmount(increaseCurrencyValue);
            Close();
        }

    }

    private void IncreaseScoreWindow()
    {
        increaseScoreValue = EditorGUILayout.IntField("Increase Score", increaseScoreValue);
        if (GUILayout.Button("Add!"))
        {
            if (increaseScoreValue < 0)
                increaseScoreValue = 0;
            GameManager.Instance.IncreaseScore(increaseScoreValue);
            Close();
        }
    }

}
