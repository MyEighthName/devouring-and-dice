using UnityEngine;

public class Mine : MonoBehaviour
{
    public const float colliderRadiusMultiplier = .5f;

    public int size;

    public ResourceGenerator rg;

    public float rtSize => Resource.rtSizeMultiplier * Mathf.Sqrt(size);

    private void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(rtSize, rtSize);
        GetComponent<CircleCollider2D>().radius = colliderRadiusMultiplier * rtSize / 2;
    }
}