using UnityEngine;
using TMPro;

public class Chrono : MonoBehaviour
{
    public TextMeshProUGUI chronoText;
    private float timeElapsed = 0f;

    void Update()
    {
        timeElapsed = timeElapsed + Time.deltaTime;
        chronoText.text = FormatTime(timeElapsed);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int secondes = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, secondes);
    }
}
