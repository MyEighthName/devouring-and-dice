using UnityEngine;

public class BotMovement_Awkward : BotMovement
{
    protected override float GetVisionRadius()
    {
        return 8 * entity.rtSize * transform.lossyScale.x;
    }

    protected override bool IsScared(Entity anotherEntity)
    {
        return entity.size * .8 < anotherEntity.size && Random.Range(0f, 1f) < .45;
    }
}
