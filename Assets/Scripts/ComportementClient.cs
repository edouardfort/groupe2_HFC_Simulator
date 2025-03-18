using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementClient : MonoBehaviour
{
    public static ComportementClient instance = null;
    void Awake(){
		if(instance == null){
			instance = this;
		}
	}
    private Argent money;
    public GameObject target;
    private GameObject[] liste;

    public float offset;

    public bool etatcommande = false;
    void Start()
    {
        money = Argent.instance;
        target = GameObject.Find("Milieu");
        transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
        transform.position = new Vector3(37.38f, 0.71f, -4.4f);
        liste = GameObject.FindGameObjectsWithTag("Client");
        offset = liste.Length;
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
    }
    public void AvancerFile(){
        GameObject[] clients = GameObject.FindGameObjectsWithTag("Client");
        foreach (GameObject client in clients)
        {
            float speed = 1f;
            Vector3 currentPos = client.transform.position;
            Vector3 targetPos = new Vector3(currentPos.x, currentPos.y, currentPos.z + 1f); 
            client.transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);
        }
    }
    void ClientPaying()
    {
        money.gagnerArgent(50);
        Destroy(gameObject);
    }

}
