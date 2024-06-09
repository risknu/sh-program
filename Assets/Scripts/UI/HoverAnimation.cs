using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Hover Settings")]
    public float scaleAmount = 1.1f;
    public float animationDuration = 0.2f;
    public GameObject showDescription;
    public AudioSource enterSound;

    private Vector3 originalScale;
    private bool isHovering = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (isHovering)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * scaleAmount, Time.deltaTime / animationDuration);
            if (showDescription == null) return;
            Color newColor = showDescription.GetComponent<Text>().color;
            newColor.a = Mathf.Lerp(showDescription.GetComponent<Text>().color.a, 1f, Time.deltaTime / animationDuration);
            showDescription.GetComponent<Text>().color = newColor;
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime / animationDuration);
            if (showDescription == null) return;
            Color newColor = showDescription.GetComponent<Text>().color;
            newColor.a = Mathf.Lerp(showDescription.GetComponent<Text>().color.a, 0f, Time.deltaTime / animationDuration);
            showDescription.GetComponent<Text>().color = newColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        enterSound.Play();
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
