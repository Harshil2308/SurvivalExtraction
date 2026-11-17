using UnityEngine;

public class JumpButton : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    public void OnJumpButtonPressed()
    {
        player.Jump();
    }
}
