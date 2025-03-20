using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChronoClientPasContent : MonoBehaviour
{
    public TextMeshPro TextChrono;
    private float timeElapsed = 30f;

    void Update()
    {
        timeElapsed -= Time.deltaTime;
        TextChrono.text = FormatTime(timeElapsed);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int secondes = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, secondes);
    }
}