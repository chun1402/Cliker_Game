using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public static ResetManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ResetGame()
    {
        GameManager.Instance.ResetEnergy();
        UpgradeManager.Instance.Reset();
        SaveManager.Instance.DeleteAll();
        Debug.Log("게임 초기화!");
    }
}