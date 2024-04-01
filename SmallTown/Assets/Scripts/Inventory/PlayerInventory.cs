using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();

    public bool RemoveItemByName(string name)
    {
        InventoryItem item = myInventory.Find(x => x.itemName == name); // Trouve l'élément dans l'inventaire par son nom

        if (item != null) // Si l'élément existe
        {
            item.numberHeld -= 1; // Décrémente le nombre d'items détenus

            if (item.numberHeld <= 0) // Si plus d'items ne sont détenus, retire l'item de l'inventaire
            {
                myInventory.Remove(item);
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this); // Marque l'inventaire comme modifié dans l'éditeur
#endif
            }
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(item); // Même si on ne retire pas l'item, le marque comme modifié si son nombre change
#endif
            }

            return true; // Retourne vrai si l'item a été trouvé et retiré
        }

        return false; // Retourne faux si l'item n'a pas été trouvé
    }

}
