using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void OnClickReset()
    {
        ResetManager.Instance.ResetGame();
    }
}