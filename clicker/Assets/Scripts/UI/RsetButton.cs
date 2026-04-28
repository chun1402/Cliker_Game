using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void OnClickReset()
    {
        ResetManager.Instance.ResetGame();
    }

    public void ResetGame()
    {
        GameManager.Instance.ResetEnergy();
        UpgradeManager.Instance.Reset();
        SaveManager.Instance.DeleteAll();
        AchievementManager.Instance.Reset(); // ← 추가
        Debug.Log("게임 초기화!");
    }
}