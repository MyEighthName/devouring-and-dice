using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfoLoader : MonoBehaviour
{
    public TMP_Text text;
    public Image image;

    private void Start()
    {
        if (PlayerInfo.name == null)
            PlayerInfo.name = text.text;
        if (PlayerInfo.sprite == null)
            PlayerInfo.sprite = image.sprite;
        if (PlayerInfo.color == null || PlayerInfo.color.a != 255)
            PlayerInfo.color = image.color;

        text.text = PlayerInfo.name;
        image.sprite = PlayerInfo.sprite;
        image.color = PlayerInfo.color;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("StartMenu"))
        {
            PlayerInfo.name = text.text;
            PlayerInfo.sprite = image.sprite;
            PlayerInfo.color = image.color;
        }
    }
}