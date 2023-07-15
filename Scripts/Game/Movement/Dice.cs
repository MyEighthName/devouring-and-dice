using UnityEngine;

public class Dice : MonoBehaviour
{
    public float cooldown;
    public float animationDuration;
    public GameObject button;
    public ImageSelector targetGraphics;

    public bool isRolled { get; private set; }
    public bool canRoll => timeSinceRoll > animationDuration + cooldown;
    public bool isInAnimationPhase => timeSinceRoll <= animationDuration;

    public float timeSinceRoll { get; private set; }

    private int value;

    private void Start()
    {
        timeSinceRoll = animationDuration + cooldown;
    }

    private void Update()
    {
        timeSinceRoll += Time.deltaTime;

        if (!isInAnimationPhase)
            AfterAnimation();

        if (button != null)
        {
            if (!isInAnimationPhase && (!canRoll || isRolled))
                button.transform.localScale = Vector2.zero;
            else
                button.transform.localScale = Vector2.one;
        }
    }

    public void Roll()
    {
        if (!isRolled && canRoll)
        {
            isRolled = true;
            timeSinceRoll = 0;
            value = Random.Range(1, 7);
            StartAnimation();

            Debug.Log($"Dice.Roll() | value: {value}");
        }
    }

    private void StartAnimation()
    {
        if (targetGraphics != null)
            targetGraphics.Change(value);
    }

    private void AfterAnimation()
    {
        if (targetGraphics != null)
            targetGraphics.Change(0);
    }

    public int GetValue()
    {
        if (!isRolled)
            return 0;

        isRolled = false;
        return value;
    }
}
