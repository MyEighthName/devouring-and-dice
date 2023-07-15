using TMPro;
using UnityEngine;

public class EntitySizeShowcase : MonoBehaviour
{
    public PlayerBox playerBox;
    public TMP_Text text;

    void Update()
    {
        text.text = $"Масса: {playerBox.totalSize}";
    }
}
