using TMPro;
using UnityEngine;

public class Entity : Resource
{
    public string entityName;

    public TMP_Text nameText;

    public float nameTextScale => rtSize / Mathf.Sqrt(startSize) / rtSizeMultiplier;

    public void Start()
    {
        if (entityType == EntityType.Player)
            entityName = PlayerInfo.name;
    }

    private void Update()
    {
        UpdateThings();
        nameText.text = string.IsNullOrEmpty(entityName) ? size.ToString() : $"{entityName}\n{size}";
        nameText.GetComponent<RectTransform>().localScale = new Vector2(nameTextScale, nameTextScale);
    }
}
