using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI energyText;

    public double Energy { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

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
        energyText.text = FormatNumber(Energy) + " ⚡";
    }

    private string FormatNumber(double n)
    {
        if (n >= 1_000_000) return $"{n / 1_000_000:F1}M";
        if (n >= 1_000) return $"{n / 1_000:F1}K";
        return $"{n:F0}";
    }
}