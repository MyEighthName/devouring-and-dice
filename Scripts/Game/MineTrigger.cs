using UnityEngine;

public class MineTrigger : MonoBehaviour
{
    public const float mineTriggerSizeMultiplier = 1.2f;
    public const float splitTime = 30f;
    public const int explodeSpeed = 6;
    public const int maxPieces = 16;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var mine = GetComponent<Mine>();
        var entity = collision.transform.GetComponent<Entity>();
        if (entity == null)
        {
            mine.size += 100;
            Destroy(collision.gameObject);
        }
        else if (entity.size > mineTriggerSizeMultiplier * mine.size)
        {
            var piecesCount = Mathf.Min(maxPieces, Mathf.Max(2, entity.size / mine.size));
            var pieceSize = entity.size / piecesCount;

            if (entity.entityType == Resource.EntityType.Player)
                entity.box.splitTime = splitTime;
            else
            {
                var rg = entity.transform.parent.GetComponent<ResourceGenerator>();
                if (rg != null)
                    rg.totalObjects += piecesCount - 1;
            }

            for (var i = 0; i < piecesCount; i++)
            {
                var positionDelta = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
                positionDelta = entity.transform.lossyScale.x * entity.rtSize / 2 * positionDelta;
                var piece = Instantiate(entity, entity.transform.position + positionDelta, Quaternion.identity, entity.transform.parent);

                var newDir = explodeSpeed * (piece.transform.position - .5f * (entity.transform.position + mine.transform.position)).normalized;
                piece.GetComponent<Movement>().SetDirection(newDir);
                piece.GetComponent<Entity>().size = pieceSize;
            }
            Destroy(entity.gameObject);
        }
    }
}
