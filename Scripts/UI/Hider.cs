using UnityEngine;

public class Hider : MonoBehaviour
{
    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
