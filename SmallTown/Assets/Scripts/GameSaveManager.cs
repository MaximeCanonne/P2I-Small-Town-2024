using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour // D�claration de la classe GameSaveManager h�ritant de MonoBehaviour
{
    private static GameSaveManager gameSave; // Instance statique de la classe GameSaveManager
    public List<ScriptableObject> objects = new List<ScriptableObject>(); // Liste d'objets de script � sauvegarder

    private void Awake() // Fonction appel�e au d�marrage de l'objet
    {
        if (gameSave == null) // Si aucune instance de GameSaveManager n'existe
        {
            gameSave = this; // D�finit cette instance comme l'instance de GameSaveManager
        }
        else // Si une instance de GameSaveManager existe d�j�
        {
            Debug.Log($"{this.gameObject.name}"); // Affiche un message de d�bogage avec le nom de l'objet
            this.gameObject.SetActive(false); // D�sactive cet objet pour �viter les doublons
        }
        DontDestroyOnLoad(this); // Emp�che la destruction de cet objet lors du chargement d'une nouvelle sc�ne
    }
}