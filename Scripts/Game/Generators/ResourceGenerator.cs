using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    public enum GeneratorType { Resource, Mine, PowerUp, Bot }

    public int amount;
    public GeneratorType type;
    public GameObject resourcePrefab;

    public int totalObjects;
    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Generate();
    }

    public void Generate()
    {
        for (; totalObjects < amount; totalObjects++)
        {
            var x = Random.Range(transform.position.x + rt.rect.xMin * transform.lossyScale.x, transform.position.x + rt.rect.xMax * transform.lossyScale.x);
            var y = Random.Range(transform.position.y + rt.rect.yMin * transform.lossyScale.y, transform.position.y + rt.rect.yMax * transform.lossyScale.y);

            var created = Instantiate(resourcePrefab, new Vector2(x, y), Quaternion.identity, transform);

            switch (type)
            {
                case GeneratorType.Resource:
                case GeneratorType.Bot:
                    created.GetComponent<Resource>().rg = this;
                    break;
                case GeneratorType.Mine:
                    created.GetComponent<Mine>().rg = this;
                    break;
                case GeneratorType.PowerUp:
                    created.GetComponent<PowerUpEntity>().rg = this;
                    break;
            }
        }
    }
}