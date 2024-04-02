using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour // Déclaration de la classe RoomMove héritant de MonoBehaviour
{
    public Vector2 cameraChange; // Changement de la position de la caméra
    public Vector3 playerChange; // Changement de la position du joueur
    public CameraController cam; // Référence au script de contrôle de la caméra
    public bool needText; // Indique si un texte doit être affiché lors du changement de pièce
    public string placeName; // Nom de l'endroit où le joueur se trouve
    public GameObject text; // Référence à l'objet de texte à afficher
    public Text placeText; // Référence au composant Text pour afficher le nom de l'endroit

    private void OnTriggerEnter2D(Collider2D collision) // Fonction appelée lorsqu'un objet entre en collision avec le déclencheur de la zone
    {
        if (collision.CompareTag("Player")) // Si l'objet entrant en collision est le joueur
        {
            // Ajustement des limites de la caméra
            cam.xmin += cameraChange.x;
            cam.xmax += cameraChange.x;
            cam.ymin += cameraChange.y;
            cam.ymax += cameraChange.y;

            // Déplacement du joueur
            collision.transform.position += playerChange;

            // Affichage du nom de l'endroit si nécessaire
            if (needText)
            {
                StartCoroutine(placeNameCo()); // Démarre la coroutine pour afficher le nom de l'endroit
            }
        }
    }

    private IEnumerator placeNameCo() // Coroutine pour afficher le nom de l'endroit
    {
        text.SetActive(true); // Active l'objet de texte
        placeText.text = placeName; // Définit le texte à afficher
        yield return new WaitForSeconds(4f); // Attend pendant 4 secondes
        text.SetActive(false); // Désactive l'objet de texte après l'attente
    }
}