using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ClickToCollect : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;

    private string defaultText = "Aucun objet";


    void Start()
    {
        // S'assurer que le texte par défaut est affiché au démarrage du jeu
        if (itemNameText != null)
        {
            itemNameText.text = defaultText;
        }
        else
        {
            // Si la référence à itemNameText n'est pas assignée dans l'Inspector, afficher un message d'erreur
            Debug.LogError("Le champ itemNameText n'est pas assigné dans l'Inspector !");
        }
    }

    void Update()
    {
        // Vérifie si l'utilisateur clique avec le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            // Crée un rayon (Ray) partant du point où la souris se trouve à l'écran
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; // Variable pour stocker l'objet touché par le rayon

            // Effectue un Raycast pour vérifier si quelque chose est touché par le rayon
            if (Physics.Raycast(ray, out hit))
            {
                // Vérifie si l'objet touché a le tag "Clickable"
                if (hit.collider.CompareTag("Clickable"))
                {
                    // Récupère le nom de l'objet collecté
                    string itemName = hit.collider.gameObject.name;

                    // Affiche le nom de l'objet dans le HUD
                    itemNameText.text = itemName;

                    // Désactive l'objet collecté pour simuler sa disparition
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}
