using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChronoClientPasContent : MonoBehaviour
{
    public static ChronoClientPasContent instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private ComportementClient comportement;
    public TextMeshPro TextChrono;
    private float timeElapsed = 30f;

    private bool etatchrono = false;

    GameObject[] clients;

    void Start()
    {

    }

    void Update()
    {
        if (TextChrono == null)
        {
            Debug.LogError("TextChrono n'est pas assigné dans l'inspecteur !");
            return;
        }
        if (etatchrono == true)
        {
            timeElapsed -= Time.deltaTime;
        }
        TextChrono.text = FormatTime(timeElapsed);
    }
    public void DemarrerChrono()
    {
        clients = GameObject.FindGameObjectsWithTag("Client");
        etatchrono = true;
    }

    public void StopTimer()
    {
        etatchrono = false;
    }
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int secondes = Mathf.FloorToInt(time % 60);
        if (secondes == 0)
        {
            comportement = ComportementClient.instance;
            comportement.ClientPasContent(clients[0]);
            ResetTimer();
        }
        return string.Format("{0:0}:{1:00}", minutes, secondes);
    }

    public void ResetTimer()
    {
        timeElapsed = 30f;
    }
}