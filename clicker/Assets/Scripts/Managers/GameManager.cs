using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI energyText;

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
        string val = PlayerPrefs.GetString("Energy", "0");
        Energy = double.Parse(val);
        UpdateUI();
    }

    void Update()
    {
        // PPS 자동 생산
        if (pps > 0)
        {
            ticker += Time.deltaTime;
            if (ticker >= 1f)
            {
                AddEnergy(pps * ticker);
                ticker = 0;
            }
        }

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
    }

    private string FormatNumber(double n)
    {
        if (n >= 1_000_000) return $"{n / 1_000_000:F1}M";
        if (n >= 1_000) return $"{n / 1_000:F1}K";
        return $"{n:F0}";
    }
}