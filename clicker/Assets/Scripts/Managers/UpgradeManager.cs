using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    [SerializeField] private List<UpgradeData> allUpgrades;
    private Dictionary<UpgradeData, int> owned = new();

    public double TotalPPS { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        foreach (var u in allUpgrades)
            owned[u] = 0;
    }

    public bool TryBuy(UpgradeData data)
    {
        double cost = data.GetCost(owned[data]);
        if (GameManager.Instance.Energy < cost) return false;

        GameManager.Instance.SpendEnergy(cost);
        owned[data]++;
        RecalculatePPS();
        return true;
    }

    private void RecalculatePPS()
    {
        TotalPPS = 0;
        foreach (var u in allUpgrades)
            TotalPPS += u.GetPPS(owned[u]);

        GameManager.Instance.SetPPS(TotalPPS);
    }
    //저장
    public void Save()
    {
        foreach (var pair in owned)
            PlayerPrefs.SetInt(pair.Key.upgradeName, pair.Value);
    }

    // 불러오기
    private void Load()
    {
        foreach (var u in allUpgrades)
            owned[u] = PlayerPrefs.GetInt(u.upgradeName, 0);
    }

    public int GetOwned(UpgradeData data) => owned[data];
    public double GetCost(UpgradeData data) => data.GetCost(owned[data]);
}