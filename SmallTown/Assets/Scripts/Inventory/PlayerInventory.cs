using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    public bool RemoveItemByName(string name)
    {
        InventoryItem item = myInventory.Find(x => x.itemName == name);
        if (item != null)
        {
            myInventory.Remove(item);
#if UNITY_EDITOR
            // Marquez l'inventaire comme modifié dans l'éditeur
            UnityEditor.EditorUtility.SetDirty(this);
#endif
            return true; // Retourne vrai si l'item a été trouvé et retiré
        }
        return false; // Retourne faux si l'item n'a pas été trouvé
    }
}