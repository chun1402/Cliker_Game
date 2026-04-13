using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // 저장
    public void Save(double energy, Dictionary<UpgradeData, int> owned)
    {
        PlayerPrefs.SetString("Energy", energy.ToString());

        foreach (var pair in owned)
        {
            PlayerPrefs.SetInt(pair.Key.upgradeName, pair.Value);
        }

        PlayerPrefs.Save();
        Debug.Log("저장 완료!");
    }

    // 불러오기
    public double LoadEnergy()
    {
        string val = PlayerPrefs.GetString("Energy", "0");
        return double.Parse(val);
    }

    public int LoadOwned(UpgradeData data)
    {
        return PlayerPrefs.GetInt(data.upgradeName, 0);
    }
}