using UnityEngine;

[CreateAssetMenu(fileName = "AchievementData", menuName = "Clicker/Achievement")]
public class AchievementData : ScriptableObject
{
    public string achievementName;
    public string description;
    public double requirement;  // 달성 조건 수치
    public AchievementType type;
}

public enum AchievementType
{
    TotalEnergy,      // 총 에너지 획득량
    TotalClicks,      // 총 클릭 횟수
    PrestigeCount,    // 환생 횟수
}