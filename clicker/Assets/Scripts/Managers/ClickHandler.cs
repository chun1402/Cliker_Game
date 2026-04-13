using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private double energyPerClick = 1;

    public void OnClick()
    {
        GameManager.Instance.AddEnergy(energyPerClick);
        Debug.Log("클릭! 현재 에너지: " + GameManager.Instance.Energy);
    }
}