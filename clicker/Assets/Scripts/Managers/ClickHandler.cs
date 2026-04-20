using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private double energyPerClick = 1;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.AddEnergy(energyPerClick);
        FloatingTextManager.Instance.ShowAt($"+{energyPerClick}", eventData.position);
        Debug.Log("클릭! 현재 에너지: " + GameManager.Instance.Energy);
    }
}