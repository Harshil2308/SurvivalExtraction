using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCamera : MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float touchSensitivity = 0.1f;

    private int activePointerId = -1;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (activePointerId != -1)
            return;

        activePointerId = eventData.pointerId;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId != activePointerId)
            return;

        Vector2 touchDelta = eventData.delta * touchSensitivity;

        player.SetLookInput(touchDelta);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId != activePointerId)
            return;

        activePointerId = -1;
    }
}
