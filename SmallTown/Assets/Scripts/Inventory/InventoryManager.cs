using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Principal;
using System.Diagnostics.SymbolStore;

public class InventoryManager : MonoBehaviour // D�claration de la classe InventoryManager h�ritant de MonoBehaviour
{
    [Header("Inventory Informations")]
    public PlayerInventory playerInventory; // Inventaire du joueur
    [SerializeField] private GameObject blankInventorySlot; // GameObject repr�sentant un emplacement d'inventaire vide
    [SerializeField] private GameObject inventoryPanel; // Panneau d'affichage de l'inventaire
    [SerializeField] private TextMeshProUGUI descriptionText; // Texte pour afficher la description de l'objet s�lectionn�
    [SerializeField] private GameObject useButton; // Bouton pour utiliser l'objet s�lectionn�
    public InventoryItem currentItem; // Objet actuellement s�lectionn� dans l'inventaire

    // M�thode pour d�finir le texte de description et l'activation du bouton d'utilisation
    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description; // D�finit le texte de description
        useButton.SetActive(buttonActive); // Active ou d�sactive le bouton d'utilisation en fonction du param�tre
    }

    // M�thode pour cr�er les emplacements d'inventaire
    void MakeInventorySlots()
    {
        if (playerInventory) // V�rifie si l'inventaire du joueur existe
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++) // Parcours tous les objets de l'inventaire du joueur
            {
                GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity); // Instancie un nouvel emplacement d'inventaire
                temp.transform.SetParent(inventoryPanel.transform); // D�finit le panneau d'inventaire comme parent de l'emplacement
                InventorySlot newSlot = temp.GetComponent<InventorySlot>(); // R�cup�re le composant InventorySlot de l'emplacement
                if (newSlot) // V�rifie si le composant InventorySlot a �t� r�cup�r� avec succ�s
                {
                    newSlot.Setup(playerInventory.myInventory[i], this); // Initialise l'emplacement d'inventaire avec l'objet correspondant
                }
            }
        }
    }

    // M�thode appel�e lorsque le GameObject devient activ�
    void OnEnable()
    {
        ClearInventorySlots(); // Efface les emplacements d'inventaire existants
        MakeInventorySlots(); // Cr�e les nouveaux emplacements d'inventaire
        SetTextAndButton("", false); // R�initialise le texte de description et d�sactive le bouton d'utilisation
    }

    // M�thode pour effacer les emplacements d'inventaire
    void ClearInventorySlots()
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++) // Parcours tous les enfants du panneau d'inventaire
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject); // D�truit chaque enfant (emplacement d'inventaire)
        }
    }

    // M�thode pour configurer la description et le bouton d'utilisation
    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem; // D�finit le nouvel objet s�lectionn�
        descriptionText.text = newDescriptionString; // D�finit le texte de description
        useButton.SetActive(isButtonUsable); // Active ou d�sactive le bouton d'utilisation en fonction du param�tre
    }

    // M�thode appel�e lorsque le bouton d'utilisation est press�
    public void UseButtonPressed()
    {
        if (currentItem) // V�rifie si un objet est actuellement s�lectionn�
        {
            currentItem.Use(); // Utilise l'objet actuellement s�lectionn�
        }
    }
}