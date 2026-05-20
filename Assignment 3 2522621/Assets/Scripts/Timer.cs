using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject finishPanel;
    public TextMeshProUGUI finalTimeText;

    float time;
    bool running = true;

    void Update()
    {
        if (!running) return;

        time += Time.deltaTime;
        timerText.text = FormatTime(time);
    }
    public void StopTimer()
    {
        running = false;
        finishPanel.SetActive(true);
        finalTimeText.text = "Final Time: " + FormatTime(time);
    }

    string FormatTime(float t)
    {
        int minutes = Mathf.FloorToInt(t / 60f);
        float seconds = t % 60f;
        return minutes.ToString("00") + ":" + seconds.ToString("00.00");
    }
}