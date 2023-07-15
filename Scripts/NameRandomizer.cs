using UnityEngine;

public class NameRandomizer : MonoBehaviour
{
    public static string[] names = new[] {
        "doctortransparent",
        "agent",
        "salami",
        "gobrrr",
        "gus",
        ":)",
        "human",
        "bob",
        "johnny"
    };

    public Entity entity;

    private void Start()
    {
        entity.entityName = names[Random.Range(0, names.Length)];
    }
}
