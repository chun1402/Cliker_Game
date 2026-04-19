using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private double energyPerClick = 1;

    public void OnClick()
    {
        GameManager.Instance.AddEnergy(energyPerClick);

        // RectTransform의 anchoredPosition 직접 넘기기
        RectTransform rect = GetComponent<RectTransform>();
        FloatingTextManager.Instance.ShowAt($"+{energyPerClick}", rect.anchoredPosition);

        Debug.Log("클릭! 현재 에너지: " + GameManager.Instance.Energy);
    }
}