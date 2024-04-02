using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Principal;
using System.Diagnostics.SymbolStore;

public class InventoryManager : MonoBehaviour // Déclaration de la classe InventoryManager héritant de MonoBehaviour
{
    [Header("Inventory Informations")]
    public PlayerInventory playerInventory; // Inventaire du joueur
    [SerializeField] private GameObject blankInventorySlot; // GameObject représentant un emplacement d'inventaire vide
    [SerializeField] private GameObject inventoryPanel; // Panneau d'affichage de l'inventaire
    [SerializeField] private TextMeshProUGUI descriptionText; // Texte pour afficher la description de l'objet sélectionné
    [SerializeField] private GameObject useButton; // Bouton pour utiliser l'objet sélectionné
    public InventoryItem currentItem; // Objet actuellement sélectionné dans l'inventaire

    // Méthode pour définir le texte de description et l'activation du bouton d'utilisation
    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description; // Définit le texte de description
        useButton.SetActive(buttonActive); // Active ou désactive le bouton d'utilisation en fonction du paramètre
    }

    // Méthode pour créer les emplacements d'inventaire
    void MakeInventorySlots()
    {
        if (playerInventory) // Vérifie si l'inventaire du joueur existe
        {
            for (int i = 0; i < playerInventory.myInventory.Count; i++) // Parcours tous les objets de l'inventaire du joueur
            {
                GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity); // Instancie un nouvel emplacement d'inventaire
                temp.transform.SetParent(inventoryPanel.transform); // Définit le panneau d'inventaire comme parent de l'emplacement
                InventorySlot newSlot = temp.GetComponent<InventorySlot>(); // Récupère le composant InventorySlot de l'emplacement
                if (newSlot) // Vérifie si le composant InventorySlot a été récupéré avec succès
                {
                    newSlot.Setup(playerInventory.myInventory[i], this); // Initialise l'emplacement d'inventaire avec l'objet correspondant
                }
            }
        }
    }

    // Méthode appelée lorsque le GameObject devient activé
    void OnEnable()
    {
        ClearInventorySlots(); // Efface les emplacements d'inventaire existants
        MakeInventorySlots(); // Crée les nouveaux emplacements d'inventaire
        SetTextAndButton("", false); // Réinitialise le texte de description et désactive le bouton d'utilisation
    }

    // Méthode pour effacer les emplacements d'inventaire
    void ClearInventorySlots()
    {
        for (int i = 0; i < inventoryPanel.transform.childCount; i++) // Parcours tous les enfants du panneau d'inventaire
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject); // Détruit chaque enfant (emplacement d'inventaire)
        }
    }

    // Méthode pour configurer la description et le bouton d'utilisation
    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem; // Définit le nouvel objet sélectionné
        descriptionText.text = newDescriptionString; // Définit le texte de description
        useButton.SetActive(isButtonUsable); // Active ou désactive le bouton d'utilisation en fonction du paramètre
    }

    // Méthode appelée lorsque le bouton d'utilisation est pressé
    public void UseButtonPressed()
    {
        if (currentItem) // Vérifie si un objet est actuellement sélectionné
        {
            currentItem.Use(); // Utilise l'objet actuellement sélectionné
        }
    }
}