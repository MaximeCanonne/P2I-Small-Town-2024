using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();

    public bool RemoveItemByName(string name)
    {
        // Trouvez l'élément dans l'inventaire par son nom
        InventoryItem item = myInventory.Find(x => x.itemName == name);

        // Si l'élément existe
        if (item != null)
        {
            // Décrémentez le nombre d'items détenus
            item.numberHeld -= 1;

            // Si plus d'items ne sont détenus, retirez l'item de l'inventaire
            if (item.numberHeld <= 0)
            {
                myInventory.Remove(item);
#if UNITY_EDITOR
                // Marquez l'inventaire comme modifié dans l'éditeur
                UnityEditor.EditorUtility.SetDirty(this);
#endif
            }
            else
            {
#if UNITY_EDITOR
                // Même si on ne retire pas l'item, marquez-le comme modifié si son nombre change
                UnityEditor.EditorUtility.SetDirty(item);
#endif
            }

            return true; // Retourne vrai si l'item a été trouvé et retiré
        }

        return false; // Retourne faux si l'item n'a pas été trouvé
    }

}
