using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue; // Référence à l'objet représentant l'indice contextuel

    public void Enable() // Méthode pour activer l'indice contextuel
    {
        contextClue.SetActive(true); // Active visuellement l'indice contextuel dans la scène Unity
    }

    public void Disable() // Méthode pour désactiver l'indice contextuel
    {
        contextClue.SetActive(false); // Désactive visuellement l'indice contextuel dans la scène Unity
    }
}