using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    [Header("Joystick References")]
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;

    [Header("Joystick Settings")]
    [SerializeField] private float handleRange = 80f;

    public Vector2 InputDirection { get; private set; }

    private void Start()
    {
        handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPosition;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out localPosition
        );

        Vector2 direction = localPosition / (background.rect.size / 2f);

        InputDirection = Vector2.ClampMagnitude(direction, 1f);

        handle.anchoredPosition = InputDirection * handleRange;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDirection = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
