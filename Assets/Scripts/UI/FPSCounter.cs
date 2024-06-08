using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [Header("FPS Settings")]
    public Text FPSText;
    private float deltaTime = 0.0f;
    private float updateRate = 1.5f;
    private int fps = 0;

    public void Start()
    {
        FPSText = GetComponent<Text>();
    }

    private void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        if (Time.time > updateRate)
        {
            fps = Mathf.RoundToInt(1.0f / deltaTime);
            updateRate = Time.time + 1.5f;
        }

        FPSText.text = "FPS: "+fps.ToString();
    }
}
