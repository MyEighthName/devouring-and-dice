using UnityEngine;

public class BotMovement_Random : Movement
{
    protected override bool IsToRollDice()
    {
        return dice.canRoll && !dice.isRolled && Random.Range(0f, 1f) < .01;
    }

    protected override void UpdateInputDirection()
    {
        inputDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
