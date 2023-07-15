using UnityEngine;


public class ScreenTouchHandler : MonoBehaviour
{
    private const float diceCooldownDelta = 0f;

    public PlayerMovement movement;

    private void Awake()
    {
        Input.simulateMouseWithTouches = true;
    }

    private void Update()
    {
        movement.inputDirection = Vector2.zero;
        if (Input.GetMouseButtonDown(0))
            OnClick();
    }

    private void OnClick()
    {
        if (movement.box.isDiceRolled && movement.box.dice.timeSinceRoll > movement.box.dice.animationDuration - diceCooldownDelta)
            movement.inputDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - movement.transform.position;
    }
}
