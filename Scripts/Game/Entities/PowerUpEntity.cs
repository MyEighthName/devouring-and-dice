using UnityEngine;
using UnityEngine.UI;

public class PowerUpEntity : MonoBehaviour
{
    public float damageMultiplier = 1f;
    public float speedMultiplier = 1f;
    public float eatingMultiplier = 1f;
    public float damageTakingReduction = 0f;

    public float duration;


    public Image image;
    public Rigidbody2D rb;

    public ResourceGenerator rg;

    private bool isUsed;

    public Sprite sprite => image.sprite;
    public Color color => image.color;

    private void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
    }

    public PowerUp FromEntity()
    {
        if (isUsed)
            return PowerUp.empty;
        isUsed = true;
        return new PowerUp(damageMultiplier, speedMultiplier, eatingMultiplier, damageTakingReduction, duration, sprite, color);
    }
}
