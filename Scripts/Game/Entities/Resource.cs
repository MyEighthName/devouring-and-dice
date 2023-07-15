using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public const float startSize = 100;
    public const float rtSizeMultiplier = 6f;
    public const float colliderRadiusMultiplier = .8f;

    public enum EntityType
    {
        Resource,
        Player,
        AFKBot,
        Bot
    }

    public EntityType entityType;

    public int size;
    public Dice dice;
    public PlayerBox box;

    public RectTransform rectTransform;
    public Rigidbody2D rb;
    public CircleCollider2D circleCollider;

    public ResourceGenerator rg;

    public float rtSize => Mathf.Sqrt(size) * rtSizeMultiplier;

    public List<PowerUp> powerUps = new List<PowerUp>();
    public float damageMultiplier => powerUps.Select(pu => pu.damageMultiplier).Aggregate(1f, (e1, e2) => e1 * e2);
    public float speedMultiplier => powerUps.Select(pu => pu.speedMultiplier).Aggregate(1f, (e1, e2) => e1 * e2);
    public float eatingMultiplier => powerUps.Select(pu => pu.eatingMultiplier).Aggregate(1f, (e1, e2) => e1 * e2);
    public float damageTakingReduction => powerUps.Select(pu => pu.damageTakingReduction).Sum();

    private void Update()
    {
        UpdateThings();
    }

    protected void UpdateThings()
    {
        if (size <= 0)
        {
            if (box != null && box.count == 1)
            {
                box.CallDeathScreen();
            }
            else
            {
                if (rg != null)
                    rg.totalObjects--;
                Destroy(gameObject);
            }
        }

        rectTransform.sizeDelta = new Vector2(rtSize, rtSize);
        circleCollider.radius = colliderRadiusMultiplier * rtSize / 2;
        rb.mass = size;

        foreach (var powerUp in powerUps)
            powerUp.LowerDuration(Time.deltaTime);
        powerUps = powerUps.Where(pu => pu.isActive).ToList();
    }
}
