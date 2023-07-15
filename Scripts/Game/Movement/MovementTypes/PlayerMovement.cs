public class PlayerMovement : Movement
{
    // Doing some ResourceMovement.cs but not really
    protected override bool IsToRollDice()
    {
        // dice rolls when dice button is pressed
        return false;
    }

    protected override void UpdateInputDirection() { }
}
