using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour // Déclaration de la classe GameSaveManager héritant de MonoBehaviour
{
    private static GameSaveManager gameSave; // Instance statique de la classe GameSaveManager
    public List<ScriptableObject> objects = new List<ScriptableObject>(); // Liste d'objets de script à sauvegarder

    private void Awake() // Fonction appelée au démarrage de l'objet
    {
        if (gameSave == null) // Si aucune instance de GameSaveManager n'existe
        {
            gameSave = this; // Définit cette instance comme l'instance de GameSaveManager
        }
        else // Si une instance de GameSaveManager existe déjà
        {
            Debug.Log($"{this.gameObject.name}"); // Affiche un message de débogage avec le nom de l'objet
            this.gameObject.SetActive(false); // Désactive cet objet pour éviter les doublons
        }
        DontDestroyOnLoad(this); // Empêche la destruction de cet objet lors du chargement d'une nouvelle scène
    }
}