using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrestigeButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;

    void Update()
    {
        bool canPrestige = PrestigeManager.Instance.CanPrestige();
        button.interactable = canPrestige;

        int count = PrestigeManager.Instance.GetPrestigeCount();
        buttonText.text = canPrestige
            ? $"⭐ reincarnation! (x{count + 1})"
            : $"1M needed for reincarnation";
    }

    public void OnClickPrestige()
    {
        PrestigeManager.Instance.Prestige();
    }
}