using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff to change")] // En-tête pour les éléments UI à modifier dans l'inspecteur Unity
    [SerializeField] private TextMeshProUGUI itemNumberText; // Texte pour afficher le nombre d'objets détenus dans cet emplacement
    [SerializeField] private Image itemImage; // Image représentant l'objet dans cet emplacement

    [Header("Variables from the item")] // En-tête pour les variables issues de l'objet
    public InventoryItem thisItem; // Référence à l'objet InventoryItem associé à cet emplacement
    public InventoryManager thisManager; // Référence au gestionnaire d'inventaire associé à cet emplacement

    // Méthode pour configurer l'emplacement d'inventaire avec un nouvel objet et un gestionnaire d'inventaire
    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem; // Définit le nouvel objet associé à cet emplacement
        thisManager = newManager; // Définit le nouveau gestionnaire d'inventaire associé à cet emplacement
        if (thisItem) // Vérifie si un objet est associé à cet emplacement
        {
            itemImage.sprite = thisItem.itemImage; // Affiche l'image de l'objet dans l'emplacement
            itemNumberText.text = "" + thisItem.numberHeld; // Affiche le nombre d'objets détenus dans cet emplacement
        }
    }

    // Méthode appelée lorsque l'emplacement d'inventaire est cliqué
    public void ClickedOn()
    {
        if (thisItem) // Vérifie si un objet est associé à cet emplacement
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription, thisItem.usable, thisItem); // Configure la description et le bouton d'utilisation dans le gestionnaire d'inventaire avec les informations de cet objet
        }
    }
}