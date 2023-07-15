using UnityEngine;

public class SizeRandomizer : MonoBehaviour
{
    public Resource resource;
    public Vector2Int sizeBorders;

    private void Start()
    {
        resource.size = Random.Range(sizeBorders.x, sizeBorders.y);
    }
}
