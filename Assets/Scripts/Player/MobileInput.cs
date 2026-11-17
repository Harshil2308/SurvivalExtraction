using UnityEngine;

public class MobileInput : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private VirtualJoystick joystick;
    [SerializeField] private PlayerController player;

    private void Update()
    {
        if (joystick == null || player == null)
            return;

        player.SetMoveInput(joystick.InputDirection);
    }
}
