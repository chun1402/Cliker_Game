using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class AchievementPopup : MonoBehaviour
{
    public static AchievementPopup Instance { get; private set; }

    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descText;

    private Queue<(string name, string desc)> popupQueue = new();
    private bool isShowing = false;

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

        popupQueue.Enqueue((name, desc));
        if (!isShowing) StartCoroutine(ShowNext());
    }

    private IEnumerator HideAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        popupPanel.SetActive(false);
    }

    private IEnumerator ShowNext()
    {
        isShowing = true;
        while (popupQueue.Count > 0)
        {
            var (name, desc) = popupQueue.Dequeue();
            nameText.text = name;
            descText.text = desc;
            popupPanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            popupPanel.SetActive(false);
            yield return new WaitForSeconds(0.5f);  // 팝업 사이 간격
        }
        isShowing = false;
    }

}