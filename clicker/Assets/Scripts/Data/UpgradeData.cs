using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Clicker/Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public double baseCost;
    public double basePPS;
    public float costMultiplier = 1.15f;

    public double GetCost(int owned)
    {
        return System.Math.Floor(baseCost * System.Math.Pow(costMultiplier, owned));
    }

    public double GetPPS(int owned)
    {
        return basePPS * owned;
    }
}