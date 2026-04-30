using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    [SerializeField] private List<UpgradeData> allUpgrades;
    private Dictionary<UpgradeData, int> owned = new();
    private LinkedList<UpgradeData> upgradeChain = new();
    private SortedDictionary<double, UpgradeData> sortedUpgrades = new();

    public double TotalPPS { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        foreach (var u in allUpgrades)
        {
            owned[u] = 0;
            sortedUpgrades[u.baseCost] = u; // ← 가격순 자동 정렬
        }

    }

    void Start()
    {
        Load();
        RecalculatePPS();
        GameManager.Instance.ApplyOfflineReward(); // GameManager의 메서드 호출
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

    public UpgradeData GetNextLocked()
    {
        foreach (var u in upgradeChain)
        {
            if (owned[u] == 0) return u; // 아직 안 산 첫 번째
        }
        return null;
    }

    private void RecalculatePPS()
    {
        TotalPPS = 0;
        foreach (var u in allUpgrades)
            TotalPPS += u.GetPPS(owned[u]);

        GameManager.Instance.SetPPS(TotalPPS);
    }

    // 가격순으로 정렬된 업그레이드 반환
    public IEnumerable<UpgradeData> GetSortedUpgrades()
    {
        return sortedUpgrades.Values;
    }


    //저장
    // UpgradeManager.cs의 Save()
    public void Save()
    {
        foreach (var pair in owned)
            PlayerPrefs.SetInt(pair.Key.upgradeName, pair.Value);
    }

    // 불러오기
    private void Load()
    {
        foreach (var u in allUpgrades)
            owned[u] = SaveManager.Instance.LoadOwned(u);
    }

    public int GetOwned(UpgradeData data) => owned[data];
    public double GetCost(UpgradeData data) => data.GetCost(owned[data]);

    public void Reset()
    {
        foreach (var u in allUpgrades)
            owned[u] = 0;

        RecalculatePPS();
    }

}