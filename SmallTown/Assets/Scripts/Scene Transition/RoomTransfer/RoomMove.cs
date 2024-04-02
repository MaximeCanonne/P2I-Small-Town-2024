using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour // D�claration de la classe RoomMove h�ritant de MonoBehaviour
{
    public Vector2 cameraChange; // Changement de la position de la cam�ra
    public Vector3 playerChange; // Changement de la position du joueur
    public CameraController cam; // R�f�rence au script de contr�le de la cam�ra
    public bool needText; // Indique si un texte doit �tre affich� lors du changement de pi�ce
    public string placeName; // Nom de l'endroit o� le joueur se trouve
    public GameObject text; // R�f�rence � l'objet de texte � afficher
    public Text placeText; // R�f�rence au composant Text pour afficher le nom de l'endroit

    private void OnTriggerEnter2D(Collider2D collision) // Fonction appel�e lorsqu'un objet entre en collision avec le d�clencheur de la zone
    {
        if (collision.CompareTag("Player")) // Si l'objet entrant en collision est le joueur
        {
            // Ajustement des limites de la cam�ra
            cam.xmin += cameraChange.x;
            cam.xmax += cameraChange.x;
            cam.ymin += cameraChange.y;
            cam.ymax += cameraChange.y;

            // D�placement du joueur
            collision.transform.position += playerChange;

            // Affichage du nom de l'endroit si n�cessaire
            if (needText)
            {
                StartCoroutine(placeNameCo()); // D�marre la coroutine pour afficher le nom de l'endroit
            }
        }
    }

    private IEnumerator placeNameCo() // Coroutine pour afficher le nom de l'endroit
    {
        text.SetActive(true); // Active l'objet de texte
        placeText.text = placeName; // D�finit le texte � afficher
        yield return new WaitForSeconds(4f); // Attend pendant 4 secondes
        text.SetActive(false); // D�sactive l'objet de texte apr�s l'attente
    }
}