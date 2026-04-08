using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private double energyPerClick = 1;

    public void OnClick()
    {
        GameManager.Instance.AddEnergy(energyPerClick);
    }
}