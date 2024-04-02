using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour // Déclaration de la classe SceneTransition héritant de MonoBehaviour
{
    public string sceneToLoad; // Nom de la scène à charger
    public Vector2 playerPosition; // Position du joueur dans la nouvelle scène
    public VectorValue playerStorage; // Valeur de stockage de la position du joueur

    public void OnTriggerEnter2D(Collider2D collision) // Fonction appelée lorsqu'un objet entre en collision avec le déclencheur de la zone
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) // Si l'objet entrant en collision est le joueur et n'est pas un déclencheur
        {
            playerStorage.initialValue = playerPosition; // Stocke la position du joueur dans le script de gestion du joueur
            SceneManager.LoadScene(sceneToLoad); // Charge la nouvelle scène
        }
    }
}