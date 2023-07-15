using System.Linq;
using UnityEngine;

public abstract class BotMovement : Movement
{
    protected abstract float GetVisionRadius();
    protected abstract bool IsScared(Entity anotherEntity);

    protected override bool IsToRollDice()
    {
        return dice.canRoll && !dice.isRolled && Random.Range(0f, 1f) < .1;
    }

    protected override void UpdateInputDirection()
    {
        inputDirection = Vector2.zero;

        var colliders = Physics2D.OverlapCircleAll(transform.position, GetVisionRadius());
        foreach (var anotherEntity in colliders.Select(e => e.GetComponent<Entity>()).Where(e => e != null && e != entity))
        {
            if (IsScared(anotherEntity))
            {
                inputDirection = (transform.position - anotherEntity.transform.position).normalized;
                return;
            }
            else if (!IsScared(anotherEntity))
                inputDirection = (anotherEntity.transform.position - transform.position).normalized;
        }

        if (inputDirection == Vector2.zero)
            inputDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
