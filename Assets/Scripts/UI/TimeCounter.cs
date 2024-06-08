using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [Header("Text Settings")]
    public Text timerText;
    private float startTime;

    public void Start()
    {
        timerText = GetComponent<Text>();
    }

    public void Update()
    {
        float elapsedTime = Time.time - startTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);

        string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                                                timeSpan.Hours,
                                                timeSpan.Minutes,
                                                timeSpan.Seconds,
                                                timeSpan.Milliseconds);
        timerText.text = formattedTime;
    }
}
