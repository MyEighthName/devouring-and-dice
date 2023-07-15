public class BotMovement_Kamikaze : BotMovement
{
    protected override float GetVisionRadius()
    {
        return 6 * entity.rtSize * transform.lossyScale.x;
    }

    protected override bool IsScared(Entity anotherEntity)
    {
        return false;
    }
}
