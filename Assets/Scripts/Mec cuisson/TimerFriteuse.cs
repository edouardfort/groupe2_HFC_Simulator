using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerFriteuse : MonoBehaviour
{
    public TextMeshPro timerText; 
    public TextMeshPro messafterfinish; 
    public GameObject nourriture;
    public float tempsDeCuisson; 
    private float tempsRestant;
    private bool enCuisson = false;
    private bool pret = false; 

    void Start()
    {
        timerText.gameObject.SetActive(false); 
        messafterfinish.gameObject.SetActive(false); 
        nourriture.SetActive(false); 
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
                timerText.gameObject.SetActive(false);
                Debug.Log("Les frites sont prêtes !");
                messafterfinish.gameObject.SetActive(true); 
                nourriture.gameObject.SetActive(true);
                pret = true; // 🔥 Active l'état prêt
            }
        }

        void Update()
            {
                // Vérifie si le burger est désactivé après la collecte
                if (!nourriture.activeSelf)  // Si le burger est désactivé
                {
                    messafterfinish.gameObject.SetActive(false);  // Cache le texte "Prêt"
                }
            }

    }

    void UpdateTimer()
    {
        int secondes = Mathf.FloorToInt(tempsRestant);
        timerText.text = secondes.ToString();
    }

    public void ActiverFriteuse()
    {
        if (!enCuisson) // 🔥 Empêche de relancer tant que l'objet n'est pas récupéré
        {
            enCuisson = true;
            tempsRestant = tempsDeCuisson;
            timerText.gameObject.SetActive(true);
            messafterfinish.gameObject.SetActive(false);
        }
    }

    public void ConfirmerPret() // 🔥 Nouvelle méthode pour réinitialiser l'état
    {
        pret = false;
    }
}
