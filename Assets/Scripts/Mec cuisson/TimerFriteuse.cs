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
    public int nivmachine;
    public AudioSource audioSource; // Ajoute ceci
    public AudioClip sonFin; // Ajoute ceci
    // public GameObject UPMACHINE;

    void Start()
    {
        timerText.gameObject.SetActive(false); 
        messafterfinish.gameObject.SetActive(false); 
        nourriture.SetActive(false); 
        nivmachine = 0;
    }

    void Update()
    {
        if (enCuisson)
        {
            if (tempsRestant > 0) //Fait -1 au timer
            {
                tempsRestant -= Time.deltaTime;
                UpdateTimer();
            }
            else //Arrivé à 0, le temps s'enlève et Prêt && Nourriture spawn
            {
                enCuisson = false;
                timerText.gameObject.SetActive(false);
                messafterfinish.gameObject.SetActive(true); 
                nourriture.gameObject.SetActive(true);
                
                if (audioSource != null && sonFin != null)
                {
                    audioSource.PlayOneShot(sonFin);
                }
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
        if (!enCuisson) //  Empêche de relancer tant que l'objet n'est pas récupéré
        {
            enCuisson = true;
            // tempsRestant = tempsDeCuisson; // C'était le truc d'avant
            if (nivmachine == 0){ // PARTIE QUI PERMET DE RÉDUIRE LE TEMPS DES MACHINES EN FONCTION DU NIVEAU MACHINE
                tempsRestant = 10;
            } else if (nivmachine == 1){
                tempsRestant = 8;
            } else if (nivmachine == 2){
                tempsRestant = 6;
            } else if (nivmachine == 3){
                tempsRestant = 4;
            }
            timerText.gameObject.SetActive(true);
            messafterfinish.gameObject.SetActive(false);
        } 
    }

    public void AmeliorerMachine()
    {
        if (nivmachine < 3)
        {
            nivmachine++;
            Debug.Log("UpgradeMachine" + nivmachine);  
        }
        else 
        {
            Debug.Log("Niveau Max atteint");
        }
    }
}
