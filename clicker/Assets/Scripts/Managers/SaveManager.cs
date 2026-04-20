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
        PlayerPrefs.SetString("LastSaveTime",
            System.DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());

        foreach (var pair in owned)
            PlayerPrefs.SetInt(pair.Key.upgradeName, pair.Value);

        PlayerPrefs.Save();
        Debug.Log("저장 완료!");
    }

    // 에너지 불러오기
    public double LoadEnergy()
    {
        string val = PlayerPrefs.GetString("Energy", "0");
        return double.Parse(val);
    }

    // 업그레이드 불러오기
    public int LoadOwned(UpgradeData data)
    {
        return PlayerPrefs.GetInt(data.upgradeName, 0);
    }

    // 오프라인 보상 계산
    public long GetOfflineSeconds()
    {
        if (!PlayerPrefs.HasKey("LastSaveTime")) return 0;

        long lastSaveTime = long.Parse(PlayerPrefs.GetString("LastSaveTime"));
        long nowTime = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        long offlineSeconds = nowTime - lastSaveTime;

        return System.Math.Min(offlineSeconds, 28800);
    }

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("저장 데이터 삭제!");
    }
}