using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff to change")] // En-t�te pour les �l�ments UI � modifier dans l'inspecteur Unity
    [SerializeField] private TextMeshProUGUI itemNumberText; // Texte pour afficher le nombre d'objets d�tenus dans cet emplacement
    [SerializeField] private Image itemImage; // Image repr�sentant l'objet dans cet emplacement

    [Header("Variables from the item")] // En-t�te pour les variables issues de l'objet
    public InventoryItem thisItem; // R�f�rence � l'objet InventoryItem associ� � cet emplacement
    public InventoryManager thisManager; // R�f�rence au gestionnaire d'inventaire associ� � cet emplacement

    // M�thode pour configurer l'emplacement d'inventaire avec un nouvel objet et un gestionnaire d'inventaire
    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem; // D�finit le nouvel objet associ� � cet emplacement
        thisManager = newManager; // D�finit le nouveau gestionnaire d'inventaire associ� � cet emplacement
        if (thisItem) // V�rifie si un objet est associ� � cet emplacement
        {
            itemImage.sprite = thisItem.itemImage; // Affiche l'image de l'objet dans l'emplacement
            itemNumberText.text = "" + thisItem.numberHeld; // Affiche le nombre d'objets d�tenus dans cet emplacement
        }
    }

    // M�thode appel�e lorsque l'emplacement d'inventaire est cliqu�
    public void ClickedOn()
    {
        if (thisItem) // V�rifie si un objet est associ� � cet emplacement
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription, thisItem.usable, thisItem); // Configure la description et le bouton d'utilisation dans le gestionnaire d'inventaire avec les informations de cet objet
        }
    }
}