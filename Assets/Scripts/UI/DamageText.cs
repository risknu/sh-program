using UnityEngine;

public class DamageText : MonoBehaviour
{
    [Header("Text Settings/Objects")]
    public float damage;
    public TextMesh textMesh;
    public GameObject parentObject;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = "-" + damage;
    }

    public void OnAnimationOver()
    {
        Destroy(parentObject);
    }
}
