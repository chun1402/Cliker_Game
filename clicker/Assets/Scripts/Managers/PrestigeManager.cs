using UnityEngine;

public class PrestigeManager : MonoBehaviour
{
    public static PrestigeManager Instance { get; private set; }

    private int prestigeCount;
    public float ClickMultiplier => 1f + prestigeCount * 0.1f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        prestigeCount = PlayerPrefs.GetInt("PrestigeCount", 0);
    }

    public bool CanPrestige()
    {
        return GameManager.Instance.Energy >= 1_000_000;
    }

    public void Prestige()
    {
        if (!CanPrestige()) return;

        prestigeCount++;
        PlayerPrefs.SetInt("PrestigeCount", prestigeCount);

        // 게임 초기화
        ResetManager.Instance.ResetGame();

        Debug.Log($"환생! {prestigeCount}번째 환생 / 클릭 보너스: x{ClickMultiplier:F1}");
    }

    public int GetPrestigeCount() => prestigeCount;
}