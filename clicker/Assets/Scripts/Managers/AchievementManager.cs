using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }

    [SerializeField] private List<AchievementData> allAchievements;

    private HashSet<string> unlocked = new();
    public double TotalClicks { get; private set; }
    public double TotalEnergy { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // 저장된 업적 불러오기
        foreach (var a in allAchievements)
        {
            if (PlayerPrefs.GetInt(a.achievementName, 0) == 1)
                unlocked.Add(a.achievementName);
        }

        TotalClicks = PlayerPrefs.GetFloat("TotalClicks", 0);
        TotalEnergy = PlayerPrefs.GetFloat("TotalEnergy", 0);
    }

    public void AddClick()
    {
        TotalClicks++;
        CheckAchievements();
    }

    public void AddTotalEnergy(double amount)
    {
        TotalEnergy += amount;
        CheckAchievements();
    }

    private void CheckAchievements()
    {
        foreach (var a in allAchievements)
        {
            if (unlocked.Contains(a.achievementName)) continue;

            bool achieved = a.type switch
            {
                AchievementType.TotalClicks => TotalClicks >= a.requirement,
                AchievementType.TotalEnergy => TotalEnergy >= a.requirement,
                AchievementType.PrestigeCount =>
                    PrestigeManager.Instance.GetPrestigeCount() >= a.requirement,
                _ => false
            };

            if (achieved) Unlock(a);
        }
    }

    private void Unlock(AchievementData a)
    {
        unlocked.Add(a.achievementName);
        PlayerPrefs.SetInt(a.achievementName, 1);
        AchievementPopup.Instance.Show(a.achievementName, a.description);
        Debug.Log($"Achievements achieved: {a.achievementName}");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("TotalClicks", (float)TotalClicks);
        PlayerPrefs.SetFloat("TotalEnergy", (float)TotalEnergy);
    }

    public void Reset()
    {
        unlocked.Clear();
        TotalClicks = 0;
        TotalEnergy = 0;
    }
}