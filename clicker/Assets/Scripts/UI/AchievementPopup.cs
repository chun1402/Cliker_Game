using UnityEngine;
using TMPro;
using System.Collections;

public class AchievementPopup : MonoBehaviour
{
    public static AchievementPopup Instance { get; private set; }

    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        popupPanel.SetActive(false);
    }

    public void Show(string name, string desc)
    {
        nameText.text = name;
        descText.text = desc;
        popupPanel.SetActive(true);
        StartCoroutine(HideAfter(3f));
    }

    private IEnumerator HideAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        popupPanel.SetActive(false);
    }
}