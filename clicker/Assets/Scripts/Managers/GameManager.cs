using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI ppsText;

    public double Energy { get; private set; }

    private double pps;
    private double ticker;
    private float saveTimer;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // 에너지 불러오기
        Energy = SaveManager.Instance.LoadEnergy();
        StartCoroutine(AutoProduce());
        UpdateUI();
    }

    void Update()
    {
        // 30초마다 자동저장
        saveTimer += Time.deltaTime;
        if (saveTimer >= 30f)
        {
            Save();
            saveTimer = 0;
        }
    }

    public void Save()
    {
        PlayerPrefs.SetString("Energy", Energy.ToString());
        PlayerPrefs.SetString("LastSaveTime",
            System.DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());
        UpgradeManager.Instance.Save();
        PlayerPrefs.Save();
        Debug.Log("저장 완료!");
    }

    public void SetPPS(double value) => pps = value;

    public void AddEnergy(double amount)
    {
        Energy += amount;
        UpdateUI();
    }

    public void SpendEnergy(double amount)
    {
        Energy -= amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        energyText.text = FormatNumber(Energy);
        ppsText.text = "per second " + pps.ToString("F2");
    }

    private string FormatNumber(double n)
    {
        if (n >= 1_000_000) return $"{n / 1_000_000:F1}M";
        if (n >= 1_000) return $"{n / 1_000:F1}K";
        return $"{n:F0}";
    }

    IEnumerator AutoProduce()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (pps > 0)
            {
                AddEnergy(pps);
                Debug.Log($"자동생산: {pps:F2}");
            }
        }
    }

    public void ApplyOfflineReward()
    {
        if (PlayerPrefs.HasKey("LastSaveTime"))
        {
            long lastSaveTime = long.Parse(PlayerPrefs.GetString("LastSaveTime"));
            long nowTime = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            long offlineSeconds = nowTime - lastSaveTime;

            offlineSeconds = System.Math.Min(offlineSeconds, 28800);

            if (offlineSeconds > 0)
            {
                double offlineEarned = pps * offlineSeconds;
                AddEnergy(offlineEarned);
                Debug.Log($"오프라인 보상: {offlineSeconds}초 → {offlineEarned:F1}");
            }
        }
    }

    void OnApplicationQuit() => Save();
    void OnApplicationPause(bool pause) { if (pause) Save(); }

    public void ResetEnergy()
    {
        Energy = 0;
        pps = 0;
        UpdateUI();
    }
}