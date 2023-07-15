public class BotMovement_Running : BotMovement
{
    protected override float GetVisionRadius()
    {
        return 10 * entity.rtSize * transform.lossyScale.x;
    }

    protected override bool IsScared(Entity anotherEntity)
    {
        return entity.size * .3 < anotherEntity.size;
    }
}
