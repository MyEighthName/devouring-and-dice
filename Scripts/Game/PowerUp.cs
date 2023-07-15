using UnityEngine;

public class PowerUp
{
    public static PowerUp empty => new PowerUp(1, 1, 1, 0, 0);

    public readonly float damageMultiplier = 1f;
    public readonly float speedMultiplier = 1f;
    public readonly float eatingMultiplier = 1f;
    public readonly float damageTakingReduction = 0f;
    public readonly float maxDuration;

    public Sprite sprite;
    public Color color = Color.white;

    public float duration { get; private set; }
    public bool isActive { get; private set; }

    public float timeFraction => duration / maxDuration;

    public PowerUp(float damageMultiplier, float speedMultiplier, float eatingMultiplier, float damageTakingReduction, float duration, Sprite sprite, Color color)
    {
        this.damageMultiplier = damageMultiplier;
        this.speedMultiplier = speedMultiplier;
        this.eatingMultiplier = eatingMultiplier;
        this.damageTakingReduction = damageTakingReduction;
        maxDuration = duration;
        this.duration = duration;
        this.sprite = sprite;
        this.color = color;
        isActive = true;
    }

    public PowerUp(float damageMultiplier, float speedMultiplier, float eatingMultiplier, float damageTakingReduction, float duration) :
        this(damageMultiplier, speedMultiplier, eatingMultiplier, damageTakingReduction, duration, null, Color.white) { }

    public PowerUp(PowerUp pu) :
        this(pu.damageMultiplier, pu.speedMultiplier, pu.eatingMultiplier, pu.damageTakingReduction, pu.duration, pu.sprite, pu.color) { }

    public void LowerDuration(float deltaTime)
    {
        if (isActive)
            duration -= deltaTime;
        if (duration <= 0)
            isActive = false;
    }

    public override string ToString()
    {
        return (damageMultiplier, speedMultiplier, eatingMultiplier, duration).ToString();
    }
}
