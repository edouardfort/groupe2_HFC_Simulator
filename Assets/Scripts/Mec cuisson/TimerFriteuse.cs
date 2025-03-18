using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerFriteuse : MonoBehaviour
{
    public TextMeshPro timerText; // Référence au texte 3D
    public float tempsDeCuisson = 10f; // Temps en secondes
    private float tempsRestant;
    private bool enCuisson = false;

    void Start()
    {
        timerText.gameObject.SetActive(false); // Cache le timer au début
    }

    void Update()
    {
        if (enCuisson)
        {
            if (tempsRestant > 0)
            {
                tempsRestant -= Time.deltaTime;
                UpdateTimer();
            }
            else
            {
                enCuisson = false;
                timerText.gameObject.SetActive(false); // Cache le timer à la fin
                Debug.Log("Les frites sont prêtes !");
            }
        }
    }

    void UpdateTimer()
    {
        int secondes = Mathf.FloorToInt(tempsRestant);
        timerText.text = secondes.ToString(); // Affiche juste les secondes
    }

    public void ActiverFriteuse()
    {
        if (!enCuisson)
        {
            enCuisson = true;
            tempsRestant = tempsDeCuisson;
            timerText.gameObject.SetActive(true); // Affiche le timer
        }
    }
}
