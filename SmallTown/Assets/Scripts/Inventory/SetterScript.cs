using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterScript : MonoBehaviour
{
    public GameObject InventoryMenu; // Référence au menu de l'inventaire dans la scène Unity
    private bool menuActivated; // Indicateur pour savoir si le menu de l'inventaire est activé ou non

    void Update()
    {
        if (Input.GetButtonDown("inventory") && menuActivated) // Si la touche d'ouverture du menu d'inventaire est pressée et que le menu est activé
        {
            menuActivated = false; // Désactive le menu
            InventoryMenu.SetActive(false); // Désactive visuellement le menu d'inventaire dans la scène Unity
        }
        else if (Input.GetButtonDown("inventory") && !menuActivated) // Si la touche d'ouverture du menu d'inventaire est pressée et que le menu n'est pas activé
        {
            menuActivated = true; // Active le menu
            InventoryMenu.SetActive(true); // Active visuellement le menu d'inventaire dans la scène Unity
        }
    }
}