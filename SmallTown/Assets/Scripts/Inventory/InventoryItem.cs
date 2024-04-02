using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")] // Attribut pour créer un nouvel objet dans le menu Inventory/Items
public class InventoryItem : ScriptableObject // Déclaration de la classe InventoryItem héritant de ScriptableObject
{
    public string itemName; // Nom de l'objet
    public string itemDescription; // Description de l'objet
    public Sprite itemImage; // Image représentant l'objet
    public int numberHeld; // Nombre d'exemplaires de cet objet que le joueur détient
    public bool usable; // Indique si l'objet est utilisable
    public bool unique; // Indique si l'objet est unique (non empilable)
    public UnityEvent thisEvent; // Événement Unity associé à cet objet

    public void Use() // Méthode pour utiliser l'objet
    {
        thisEvent.Invoke(); // Déclenche l'événement associé à cet objet.
    }
}