using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterScript : MonoBehaviour
{
    public GameObject InventoryMenu; // R�f�rence au menu de l'inventaire dans la sc�ne Unity
    private bool menuActivated; // Indicateur pour savoir si le menu de l'inventaire est activ� ou non

    void Update()
    {
        if (Input.GetButtonDown("inventory") && menuActivated) // Si la touche d'ouverture du menu d'inventaire est press�e et que le menu est activ�
        {
            menuActivated = false; // D�sactive le menu
            InventoryMenu.SetActive(false); // D�sactive visuellement le menu d'inventaire dans la sc�ne Unity
        }
        else if (Input.GetButtonDown("inventory") && !menuActivated) // Si la touche d'ouverture du menu d'inventaire est press�e et que le menu n'est pas activ�
        {
            menuActivated = true; // Active le menu
            InventoryMenu.SetActive(true); // Active visuellement le menu d'inventaire dans la sc�ne Unity
        }
    }
}