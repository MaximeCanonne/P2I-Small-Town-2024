using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();

    public bool RemoveItemByName(string name)
    {
        InventoryItem item = myInventory.Find(x => x.itemName == name); // Trouve l'�l�ment dans l'inventaire par son nom

        if (item != null) // Si l'�l�ment existe
        {
            item.numberHeld -= 1; // D�cr�mente le nombre d'items d�tenus

            if (item.numberHeld <= 0) // Si plus d'items ne sont d�tenus, retire l'item de l'inventaire
            {
                myInventory.Remove(item);
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(this); // Marque l'inventaire comme modifi� dans l'�diteur
#endif
            }
            else
            {
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(item); // M�me si on ne retire pas l'item, le marque comme modifi� si son nombre change
#endif
            }

            return true; // Retourne vrai si l'item a �t� trouv� et retir�
        }

        return false; // Retourne faux si l'item n'a pas �t� trouv�
    }

}
