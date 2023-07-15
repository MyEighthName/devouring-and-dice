using UnityEngine;

public class BotMovement_Smarter : BotMovement
{
    protected override float GetVisionRadius()
    {
        return 10 * entity.rtSize * transform.lossyScale.x;
    }

    protected override bool IsScared(Entity anotherEntity)
    {
        return entity.size * .8 < anotherEntity.size;
    }
}
