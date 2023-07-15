using UnityEngine;

public static class RectTransformExtensions
{
    public static void SetLeft(this RectTransform rt, float val)
    {
        rt.offsetMin = new Vector2(val, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float val)
    {
        rt.offsetMax = new Vector2(-val, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float val)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -val);
    }

    public static void SetBottom(this RectTransform rt, float val)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, val);
    }
}
