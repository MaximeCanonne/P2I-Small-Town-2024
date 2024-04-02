using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue; // R�f�rence � l'objet repr�sentant l'indice contextuel

    public void Enable() // M�thode pour activer l'indice contextuel
    {
        contextClue.SetActive(true); // Active visuellement l'indice contextuel dans la sc�ne Unity
    }

    public void Disable() // M�thode pour d�sactiver l'indice contextuel
    {
        contextClue.SetActive(false); // D�sactive visuellement l'indice contextuel dans la sc�ne Unity
    }
}