using Unity.VisualScripting;
using UnityEngine;

public class RandomBotMovement : MonoBehaviour
{
    public Entity entity;

    private void Start()
    {
        var number = Random.Range(0, 7);

        switch (number)
        {
            case 0:
            case 1:
            case 2:
                entity.AddComponent<BotMovement_Awkward>().entity = entity; break;
            case 3:
                entity.AddComponent<BotMovement_Smarter>().entity = entity; break;
            case 4:
                entity.AddComponent<BotMovement_Kamikaze>().entity = entity; break;
            case 5:
                entity.AddComponent<BotMovement_Random>().entity = entity; break;
            case 6:
                entity.AddComponent<BotMovement_Running>().entity = entity; break;
        }
    }
}