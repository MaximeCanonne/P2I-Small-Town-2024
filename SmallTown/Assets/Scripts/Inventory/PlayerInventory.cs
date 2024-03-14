using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();

    public bool RemoveItemByName(string name)
    {
        // Trouvez l'�l�ment dans l'inventaire par son nom
        InventoryItem item = myInventory.Find(x => x.itemName == name);

        // Si l'�l�ment existe
        if (item != null)
        {
            // D�cr�mentez le nombre d'items d�tenus
            item.numberHeld -= 1;

            // Si plus d'items ne sont d�tenus, retirez l'item de l'inventaire
            if (item.numberHeld <= 0)
            {
                myInventory.Remove(item);
#if UNITY_EDITOR
                // Marquez l'inventaire comme modifi� dans l'�diteur
                UnityEditor.EditorUtility.SetDirty(this);
#endif
            }
            else
            {
#if UNITY_EDITOR
                // M�me si on ne retire pas l'item, marquez-le comme modifi� si son nombre change
                UnityEditor.EditorUtility.SetDirty(item);
#endif
            }

            return true; // Retourne vrai si l'item a �t� trouv� et retir�
        }

        return false; // Retourne faux si l'item n'a pas �t� trouv�
    }

}
