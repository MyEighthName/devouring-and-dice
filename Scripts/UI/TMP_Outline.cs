using TMPro;
using UnityEngine;

public class TMP_Outline : MonoBehaviour
{
    public float outlineWidth;
    public Color outlineColor;
    public TMP_Text text;

    void Start()
    {
        text.outlineWidth = outlineWidth;
        text.outlineColor = outlineColor;
    }
}
