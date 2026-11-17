using UnityEngine;
using UnityEngine.EventSystems;

public class SprintButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerExitHandler
{
    [SerializeField] private PlayerController player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.SetSprint(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.SetSprint(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        player.SetSprint(false);
    }
}
