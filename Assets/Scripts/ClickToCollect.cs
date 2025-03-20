using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickToCollect : MonoBehaviour
{
    public static ClickToCollect instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public TextMeshProUGUI itemNameText;

    private List<string> collectedItems = new List<string>();

    private string defaultText = "Aucun objet collecté";

    public GameObject Sac;

    void Start()
    {
        if (itemNameText != null)
        {
            itemNameText.text = defaultText;
        }
        else
        {
            Debug.LogError("Le champ itemNameText n'est pas assigné dans l'Inspector !");
        }
    }

    void Update()
    {
        if (itemNameText.text == "Aucun objet collecté")
        {
            Sac.SetActive(false);
        }
        else
        {
            Sac.SetActive(true);
        }
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
                if (hit.collider.CompareTag("Clickable") && collectedItems.Count < 2)
                {
                    // Récupère le nom de l'objet collecté
                    string itemName = hit.collider.gameObject.name;

                    // Ajoute le nom de l'objet à la liste des objets collectés
                    collectedItems.Add(itemName);

                    // Met à jour le texte du HUD pour afficher la liste complète des objets collectés
                    UpdateHUD();

                    // Désactive l'objet collecté pour simuler sa disparition
                    hit.collider.gameObject.SetActive(false);
                }
                if (hit.collider.CompareTag("Client"))
                {
                    ComportementClient clientScript = hit.collider.GetComponent<ComportementClient>();

                    if (clientScript != null)
                    {
                        for (int i = 0; i < collectedItems.Count; i++)
                        {
                            collectedItems[i] = collectedItems[i].ToLower();
                        }
                        clientScript.OnRaycastHit(collectedItems);
                    }
                }
                if (hit.collider.CompareTag("Poubelle"))
                {
                    DeleteInventory();
                }
            }
        }
    }

    public void DeleteInventory()
    {
        for (int i = collectedItems.Count - 1; i >= 0; i--)
        {
            collectedItems.RemoveAt(i);
        }
        UpdateHUD();

    }


    // Méthode pour mettre à jour le texte du HUD avec la liste des objets collectés
    private void UpdateHUD()
    {
        if (collectedItems.Count > 0)
        {
            // Construit une chaîne de caractères avec tous les objets collectés
            itemNameText.text = "Objets collectés:\n";

            // Parcours chaque objet dans la liste et ajoute son nom au texte du HUD
            foreach (string item in collectedItems)
            {
                itemNameText.text += item + "\n";
            }
        }
        else
        {
            itemNameText.text = defaultText;
        }
    }
}
