using System;
using UnityEngine;
using UnityEngine.UI;

public class EntityCollision : MonoBehaviour
{
    public const float eatRangeInDeg = 160f;
    public const float biteSizeMultiplier = .6f;

    public PlayerBox box;
    public int maxPowerUpsCountIfNotPlayer;  // if playerBox == null

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.GetComponent<Resource>() != null)
            OnResourceCollision(other);
        else if (other.transform.GetComponent<PowerUpEntity>() != null)
            OnPowerUpCollision(other);
        else if (other.transform.GetComponent<TrapEntity>() != null)
            OnTrapCollision(other);
    }

    private void OnResourceCollision(Collision2D other)
    {
        if (IsInEatingAngle(other))
        {
            var r1 = GetComponent<Entity>();
            var r2 = other.transform.GetComponent<Resource>();

            if (r1.entityType == r2.entityType && r1.entityType == Resource.EntityType.Player && box.splitTime > 0)
                return;

            var biteSize = Time.deltaTime * biteSizeMultiplier * r1.size * r1.damageMultiplier;
            biteSize = Mathf.Max(1, biteSize);
            biteSize = Mathf.Round(biteSize * (1 - r2.damageTakingReduction));
            biteSize = Mathf.Min(r2.size, biteSize);

            r1.size += (int)(biteSize * r1.eatingMultiplier);
            r2.size -= (int)biteSize;
        }
    }

    private void OnPowerUpCollision(Collision2D other)
    {
        var r = GetComponent<Entity>();

        var canEat = box != null && box.puCount < box.powerUpShowcase.Length || box == null && r.powerUps.Count < maxPowerUpsCountIfNotPlayer;
        canEat = canEat && IsInEatingAngle(other);

        if (canEat)
        {
            var pue = other.transform.GetComponent<PowerUpEntity>();
            var powerUp = pue.FromEntity();
            if (box != null)
                box.AddPowerUp(powerUp);
            else
                r.powerUps.Add(powerUp);

            if (pue.rg != null)
                pue.rg.totalObjects--;
            Destroy(other.gameObject);
        }
    }

    private void OnTrapCollision(Collision2D other)
    {
        var r = GetComponent<Entity>();
        if (IsInEatingAngle(other))
        {
            var damage = other.transform.GetComponent<TrapEntity>().damage;
            r.size -= (int)damage;

            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
    }

    private bool IsInEatingAngle(Collision2D other)
    {
        var m = GetComponent<Movement>();

        if (m.direction.Equals(Vector2.zero) || transform.position.Equals(other.transform.position))
            return false;

        var movingAngle = GetAngle(Vector2.zero, m.direction);
        var collisionAngle = GetAngle(transform.position, other.transform.position);
        Func<float, float, bool> f = (a, b) => Mathf.Abs(a - b) < eatRangeInDeg / 2;

        return f(movingAngle, collisionAngle) || f(movingAngle + 360, collisionAngle) || f(movingAngle, collisionAngle + 360);
    }

    private static float GetAngle(Vector2 a, Vector2 b)
    {
        if (a.Equals(b))
            throw new ArgumentException($"ResourceCollision.GetAngle | vectors are equal ({a})");
        var angle = Mathf.Rad2Deg * Mathf.Acos((b - a).x / (b - a).magnitude);
        if (a.y > b.y)
            return 360 - angle;
        return angle;
    }
}
