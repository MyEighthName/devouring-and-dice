using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public const float moveTotalTime = .8f;
    public const float fancyNumber = .75f * 6.2493471664120801666254507341644f;

    public Resource entity;
    public Vector2 inputDirection;
    public PlayerBox box;

    public Dice dice => entity.dice;
    public RectTransform rectTransform => entity.rectTransform;
    public Rigidbody2D rb => entity.rb;

    public Vector2 position => rectTransform.anchoredPosition;
    public Vector2 direction { get; protected set; }

    private float timeMoving;

    protected void Start()
    {
        timeMoving = moveTotalTime;
    }

    protected void Update()
    {
        if (IsToRollDice())
            dice.Roll();

        UpdateInputDirection();
        if ((box != null && box.isDiceRolled || box == null && dice.isRolled) && !inputDirection.Equals(Vector2.zero))
            UpdateDirection();
    }

    protected void FixedUpdate()
    {
        timeMoving += Time.fixedDeltaTime;
        if (timeMoving > moveTotalTime)
        {
            direction = Vector2.zero;
            rb.velocity = Vector2.zero;
        }
        else
            rb.velocity = fancyNumber * Time.fixedDeltaTime * entity.rtSize * entity.speedMultiplier * direction;
    }

    protected abstract bool IsToRollDice();

    protected abstract void UpdateInputDirection();

    private void UpdateDirection()
    {
        if (box == null)
            direction = dice.GetValue() * inputDirection.normalized;
        else
            direction = box.GetDiceValue() * inputDirection.normalized;
        inputDirection = Vector2.zero;
        timeMoving = 0;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        timeMoving = 0;
    }
}
