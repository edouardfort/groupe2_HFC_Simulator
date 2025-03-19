using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerFriteuse : MonoBehaviour
{
    public TextMeshPro timerText; // Référence au texte 3D
    public TextMeshPro messafterfinish; // Texte 3D après le décompte
    public GameObject nourriture;
    public float tempsDeCuisson; //= 20f; // Temps en secondes, je l'ai mit en commentaire psk ça changeait rien du tout
    private float tempsRestant;
    private bool enCuisson = false;

    void Start()
    {
        timerText.gameObject.SetActive(false); // Cache le timer au début
        messafterfinish.gameObject.SetActive(false); // Cache le texte au début
        nourriture.SetActive(false); //Cache l'objet
    }

    void Update()
    {
        if (enCuisson)
        {
            if (tempsRestant > 0)
            {
                tempsRestant -= Time.deltaTime; //Time.deltaTime c'est une commande qui fait un compte a rebours je crois, donc en faites on soustrait une variable temps avec du temps qui passe, si j'ai bien capté.
                UpdateTimer();
            }
            else
            {
                enCuisson = false;
                timerText.gameObject.SetActive(false); // Cache le timer à la fin
                Debug.Log("Les frites sont prêtes !"); //Verif, changer cette ligne avec une phrase pour dire que c'est cuit ==> prochain mvp faire un temps pour voir si ils vont cramés ou pas.
                messafterfinish.gameObject.SetActive(true); // Montre le message prêt
                nourriture.gameObject.SetActive(true); //fait apparaitre le burger
            }

        }
    }

    void UpdateTimer()
    {
        int secondes = Mathf.FloorToInt(tempsRestant); //Mathf.FloorToInt == Renvoie le plus grand entier inférieur ou égal à f
        timerText.text = secondes.ToString(); // Affiche juste les secondes
    }

    public void ActiverFriteuse()
    {
        if (!enCuisson)
        {
            enCuisson = true;
            tempsRestant = tempsDeCuisson;
            timerText.gameObject.SetActive(true); // Affiche le timer
            messafterfinish.gameObject.SetActive(false); // Cache le mess pendant la cuisson
        }
    }
}
