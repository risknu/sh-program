using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextTyping : MonoBehaviour
{
    [Header("Typing Text Settings")]
    private float typingSpeed = 0.05f;
    private float typingSpeedNow = 0.05f;
    public string fullText;
    public float startDelay = 0f;
    public bool startEnter = false;
    public TextTyping nextText;
    public GameObject typingSoundPrefab;

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

            GameObject audioSource = Instantiate(typingSoundPrefab, transform.position, transform.rotation);
            audioSource.GetComponent<AudioSource>().Play();
            Destroy(audioSource, audioSource.GetComponent<AudioSource>().clip.length);

            if (fullText[i] == '.' || fullText[i] == '-' || fullText[i] == '?' || fullText[i] == '!')
                typingSpeedNow = typingSpeed + 0.2f;
            else if (fullText[i] == ',' || fullText[i] == ':' || fullText[i] == ')')
                typingSpeedNow = typingSpeed + 0.1f;
            else
                typingSpeedNow = typingSpeed;

            yield return new WaitForSeconds(typingSpeedNow);
        }

        if (nextText != null)
            nextText.StartCoroutine(nextText.TypeText());
    }
}
