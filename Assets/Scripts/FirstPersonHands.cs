using UnityEngine;

public class FirstPersonHands : MonoBehaviour
{
    [Header("Références")]
    public GameObject handsPrefab; // Modèle 3D des mains assigné depuis l'éditeur
    private GameObject handsInstance; // Instance des mains dans la scène
    
    [Header("Paramètres d'affichage")]
    public Vector3 positionOffset = new Vector3(0, -0.5f, 0.5f); // Décalage de position des mains par rapport à la caméra
    public Vector3 rotationOffset = Vector3.zero; // Décalage de rotation
    
    [Header("Paramètres d'animation")]
    public bool followCameraRotation = true; // Les mains suivent-elles la rotation de la caméra ?
    public float smoothingSpeed = 5f; // Vitesse de lissage du mouvement

    private Transform cameraTransform; // Référence à la caméra principale
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        // Récupérer la caméra principale
        cameraTransform = Camera.main.transform;

        if (handsPrefab != null)
        {
            // Instancier les mains en tant qu'enfant de la caméra
            handsInstance = Instantiate(handsPrefab, cameraTransform);
            handsInstance.transform.localPosition = positionOffset;
            handsInstance.transform.localRotation = Quaternion.Euler(rotationOffset);
        }
        else
        {
            Debug.LogWarning("Aucun modèle de mains assigné !");
        }
    }
    
    void Update()
    {
        if (handsInstance != null)
        {
            // Mise à jour de la position et de la rotation des mains
            targetPosition = cameraTransform.position + cameraTransform.TransformDirection(positionOffset);
            targetRotation = followCameraRotation ? cameraTransform.rotation * Quaternion.Euler(rotationOffset) : handsInstance.transform.rotation;
            
            // Lissage du mouvement
            handsInstance.transform.position = Vector3.Lerp(handsInstance.transform.position, targetPosition, Time.deltaTime * smoothingSpeed);
            handsInstance.transform.rotation = Quaternion.Slerp(handsInstance.transform.rotation, targetRotation, Time.deltaTime * smoothingSpeed);
        }
    }
}
