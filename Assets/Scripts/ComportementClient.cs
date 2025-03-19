using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementClient : MonoBehaviour
{
    public static ComportementClient instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private Argent money;
    private List<string> produitsDispo;  // Liste des produits disponibles
    private List<float> prixDispo;  // Liste des prix des produits
    private string[] produitsChoix = new string[2];  // Produits choisis par le client
    public GameObject target;
    private GameObject[] liste;

    public float offset;
    int compteur = 0;

    public bool etatcommande = false;

    public bool menuaffiche = false;
    float prixprod = 0f;

    void Start()
    {
        money = Argent.instance;
        target = GameObject.Find("Milieu");
        transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
        transform.position = new Vector3(37.38f, 0.71f, -4.4f);
        liste = GameObject.FindGameObjectsWithTag("Client");
        offset = liste.Length;
        ChoixMenu();
    }

    void Update()
    {
        float speed = 1f;
        if (etatcommande == false)
        {
            GameObject[] clients = GameObject.FindGameObjectsWithTag("Client");
            int position = System.Array.IndexOf(clients, gameObject);
            Vector3 cible = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z - position);

            transform.position = Vector3.MoveTowards(transform.position, cible, speed * Time.deltaTime);
        }
        else
        {
            ClientPaying();
        }
        if (transform.position.z == -4.36f && menuaffiche == false)
        {
            AfficherMenu();
            menuaffiche = true;
        }
        if (compteur == 2)
        {
            etatcommande = true;
        }
    }
    public void OnRaycastHit(List<string> collectedItems)
    {
        if (menuaffiche == true)
        {
            List<string> produitsac = new List<string>(collectedItems);

            compteur = 0;

            // Vérifier les produits collectés qui ne sont pas choisis par le client
            foreach (string produitCollecte in produitsac)
            {
                // Si le produit collecté n'est pas dans les produits choisis par le client
                if (!Array.Exists(produitsChoix, item => item.Equals(produitCollecte, System.StringComparison.OrdinalIgnoreCase)))
                {
                    Debug.Log("Je ne veux pas de " + produitCollecte);
                }
            }
            foreach (string produitChoisi in produitsChoix)
            {
                // Si le produit collecté correspond à un produit choisi
                if (produitsac.Exists(item => item.Equals(produitChoisi, System.StringComparison.OrdinalIgnoreCase)))
                {
                    produitsac.Remove(produitChoisi);
                    compteur = compteur + 1;
                }
            }


        }
    }


    void AfficherMenu()
    {
        GameObject Bulle = new GameObject("Bulle");
        Bulle.transform.SetParent(gameObject.transform);
        SpriteRenderer spriterenderer = Bulle.AddComponent<SpriteRenderer>();
        spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Clients/Bulle");
        Bulle.transform.localPosition = new Vector3(-12.5f, 17.5f, 0.5f);
        Bulle.transform.localScale = new Vector3(1, 1, 1);
        Bulle.transform.rotation = Quaternion.Euler(0, 180, -18);
        for (int i = 0; i < produitsChoix.Length; i++)
        {
            GameObject produitImage = new GameObject("Produit" + i);
            produitImage.transform.SetParent(Bulle.transform);

            SpriteRenderer produitRenderer = produitImage.AddComponent<SpriteRenderer>();
            produitRenderer.sprite = Resources.Load<Sprite>("Sprites/Produits/" + produitsChoix[i]);
            produitImage.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            if (i == 0)
            {
                produitImage.transform.localPosition = new Vector3(-4f, 1f, -1.5f);
            }
            else if (i == 1)
            {
                produitImage.transform.localPosition = new Vector3(1.5f, 1.7f, -2.57f);
            }
        }
    }

    // Choisir les produits et calculer le prix
    void ChoixMenu()
    {
        prixprod = 0f;
        produitsDispo = Produits.instance.produits;  // Récupérer la liste des produits disponibles
        prixDispo = Produits.instance.prix;  // Récupérer la liste des prix

        // Choisir deux produits aléatoires
        for (int i = 0; i < 2; i++)
        {
            int j = UnityEngine.Random.Range(0, produitsDispo.Count);  // Utiliser UnityEngine.Random.Range pour éviter la confusion
            produitsChoix[i] = produitsDispo[j];  // Stocker le produit choisi
            prixprod += prixDispo[j];  // Ajouter le prix du produit choisi à la somme totale
        }

        // Affichage dans la console pour vérifier
        Debug.Log("Produits choisis : " + produitsChoix[0] + ", " + produitsChoix[1]);
        Debug.Log("Prix total : " + prixprod);
    }

    // Avancer la file de clients
    public void AvancerFile()
    {
        GameObject[] clients = GameObject.FindGameObjectsWithTag("Client");
        foreach (GameObject client in clients)
        {
            float speed = 1f;
            Vector3 currentPos = client.transform.position;
            Vector3 targetPos = new Vector3(currentPos.x, currentPos.y, currentPos.z + 1f);  // Avancer dans l'axe Z
            client.transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
        }
    }

    // Processus de paiement du client
    void ClientPaying()
    {
        money.gagnerArgent(prixprod);
        Destroy(gameObject);
    }
}