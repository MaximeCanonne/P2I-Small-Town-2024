using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")] // Attribut pour cr�er un nouvel objet dans le menu Inventory/Items
public class InventoryItem : ScriptableObject // D�claration de la classe InventoryItem h�ritant de ScriptableObject
{
    public string itemName; // Nom de l'objet
    public string itemDescription; // Description de l'objet
    public Sprite itemImage; // Image repr�sentant l'objet
    public int numberHeld; // Nombre d'exemplaires de cet objet que le joueur d�tient
    public bool usable; // Indique si l'objet est utilisable
    public bool unique; // Indique si l'objet est unique (non empilable)
    public UnityEvent thisEvent; // �v�nement Unity associ� � cet objet

    public void Use() // M�thode pour utiliser l'objet
    {
        thisEvent.Invoke(); // D�clenche l'�v�nement associ� � cet objet.
    }
}