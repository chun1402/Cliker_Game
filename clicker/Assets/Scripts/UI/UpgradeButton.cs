using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeData data;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI ownedText;
    [SerializeField] private Button button;

    void Update()
    {
        double cost = UpgradeManager.Instance.GetCost(data);
        int count = UpgradeManager.Instance.GetOwned(data);

        nameText.text = data.upgradeName;
        costText.text = FormatNumber(cost);
        ownedText.text = $"x{count}";

        button.interactable = GameManager.Instance.Energy >= cost;
    }

    public void OnClickBuy()
    {
        UpgradeManager.Instance.TryBuy(data);
    }

    private string FormatNumber(double n)
    {
        if (n >= 1_000_000) return $"{n / 1_000_000:F1}M";
        if (n >= 1_000) return $"{n / 1_000:F1}K";
        return $"{n:F0}";
    }
}