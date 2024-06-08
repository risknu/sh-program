using UnityEngine;
using UnityEngine.UI;

public class ShowCurrentIcon : MonoBehaviour
{
    [Header("Assoc")]
    public Sprite[] icons;
    public string[] names;
    public PlayerController player;

    public void Start()
    {
        Image image = GetComponent<Image>();
        
        for (int i = 0; i < names.Length; i++)
        {
            if (player.ability == names[i])
            {
                image.sprite = icons[i];
                break;
            }
        }
    }
}
