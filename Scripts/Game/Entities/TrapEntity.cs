using UnityEngine;
using UnityEngine.UI;

public class TrapEntity : MonoBehaviour
{
    public float damage = 1f;

    public Image image;
    public Rigidbody2D rb;

    public Sprite sprite => image.sprite;
    public Color color => image.color;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
    }
}
