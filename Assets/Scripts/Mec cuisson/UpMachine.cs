using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMachine : MonoBehaviour
{
        public TimerFriteuse timerFriteuse;  // Référence au script TimerFriteuse

    void OnMouseDown() // Détection du clic sur l'objet
    {
        if (Argent.instance.argent >= 5 && timerFriteuse.nivmachine < 3)  // On récup la variable argent et on vérifie si elle a la tune nécessaire
        {
            Argent.instance.gagnerArgent(-5); // Retire 20 d'argent
            timerFriteuse.AmeliorerMachine();  // Améliore la machine
        } else
        {
            Debug.Log("Pas assez d'argent ou niveau max atteint !");
        }
    }
}
