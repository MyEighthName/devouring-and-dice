using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public enum Direction4 { Top, Bottom, Left, Right }

    public RectTransform rt;
    public Direction4 fillSide;
    public float progress;

    private float maxHeight;

    private void Start()
    {
        maxHeight = rt.rect.height;
    }

    private void Update()
    {
        switch (fillSide)
        {
            case Direction4.Top:
                rt.SetBottom((1 - progress) * maxHeight);
                break;
            case Direction4.Bottom:
                rt.SetTop((1 - progress) * maxHeight);
                break;
            case Direction4.Left:
                rt.SetRight((1 - progress) * maxHeight);
                break;
            case Direction4.Right:
                rt.SetLeft((1 - progress) * maxHeight);
                break;
        }
    }
}
