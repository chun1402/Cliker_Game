using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private double energyPerClick = 1;

    public void OnPointerDown(PointerEventData eventData)
    {
        double bonus = energyPerClick * PrestigeManager.Instance.ClickMultiplier;
        GameManager.Instance.AddEnergy(bonus);
        FloatingTextManager.Instance.ShowAt($"+{bonus:F1}", eventData.position);
        Debug.Log("클릭! 현재 에너지: " + GameManager.Instance.Energy);
        AudioManager.Instance.PlayClick(); // 소리 재생
        AchievementManager.Instance.AddClick();        
        AchievementManager.Instance.AddTotalEnergy(bonus); 
    }
}