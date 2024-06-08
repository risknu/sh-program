using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextTyping : MonoBehaviour
{
    [Header("Typing Text Settings")]
    public float typingSpeed = 0.05f;
    public string fullText;
    public float startDelay = 0f;
    public bool startEnter = false;
    public TextTyping nextText;

    private string currentText = "";
    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
        if (startEnter == true)
            StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            uiText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (nextText != null)
            nextText.StartCoroutine(nextText.TypeText());
    }
}
