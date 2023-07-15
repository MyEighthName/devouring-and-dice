using UnityEngine;
using UnityEngine.UI;

public class ImageSelector : MonoBehaviour
{
    public Sprite[] sprites;
    [SerializeField] private bool isRandom;

    private void Start()
    {
        if (isRandom)
            GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    public void Change(int number)
    {
        GetComponent<Image>().sprite = sprites[number];
    }
}