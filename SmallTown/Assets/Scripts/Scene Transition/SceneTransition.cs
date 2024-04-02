using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour // D�claration de la classe SceneTransition h�ritant de MonoBehaviour
{
    public string sceneToLoad; // Nom de la sc�ne � charger
    public Vector2 playerPosition; // Position du joueur dans la nouvelle sc�ne
    public VectorValue playerStorage; // Valeur de stockage de la position du joueur

    public void OnTriggerEnter2D(Collider2D collision) // Fonction appel�e lorsqu'un objet entre en collision avec le d�clencheur de la zone
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) // Si l'objet entrant en collision est le joueur et n'est pas un d�clencheur
        {
            playerStorage.initialValue = playerPosition; // Stocke la position du joueur dans le script de gestion du joueur
            SceneManager.LoadScene(sceneToLoad); // Charge la nouvelle sc�ne
        }
    }
}