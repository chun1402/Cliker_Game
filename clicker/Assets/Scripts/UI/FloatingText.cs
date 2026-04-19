using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float fadeSpeed = 1.5f;

    private TextMeshProUGUI text;
    private Color color;
    private RectTransform rect;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        color = text.color;
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;
        color.a -= fadeSpeed * Time.deltaTime;
        text.color = color;

        if (color.a <= 0)
            Destroy(gameObject);
    }

    public void SetPosition(Vector2 anchoredPos)
    {
        rect.anchoredPosition = anchoredPos;
    }

    public void SetText(string msg)
    {
        text.text = msg;
    }
}