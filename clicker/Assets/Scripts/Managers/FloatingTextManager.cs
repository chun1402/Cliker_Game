using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance { get; private set; }

    [SerializeField] private FloatingText floatingTextPrefab;
    [SerializeField] private Canvas canvas;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Show(string msg, Vector2 screenPos)
    {
        FloatingText ft = Instantiate(floatingTextPrefab, canvas.transform);

        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        // 스크린 좌표 → Canvas 로컬 좌표 변환
        Vector2 anchoredPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPos,
            null,
            out anchoredPos
        );

        ft.SetPosition(anchoredPos + new Vector2(Random.Range(-30f, 30f), 0));
        ft.SetText(msg);
    }

    public void ShowAt(string msg, Vector2 screenPos)
    {
        FloatingText ft = Instantiate(floatingTextPrefab, canvas.transform);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.GetComponent<RectTransform>(),
            screenPos,
            null,
            out Vector2 localPos
        );

        ft.SetPosition(localPos + new Vector2(Random.Range(-20f, 20f), 0));
        ft.SetText(msg);
    }
}