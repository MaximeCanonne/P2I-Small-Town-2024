using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory; // Référence sérialisée vers le script PlayerInventory
    [SerializeField] private InventoryItem thisItem; // Référence sérialisée vers l'objet InventoryItem de cet élément physique
    private static PhysicalInventoryItem PII; // Instance statique de PhysicalInventoryItem

    private void Awake() // Fonction appelée au réveil de l'objet, pour sauvegarder les données de l'inventaire lors du passage d'une scène à l'autre.
    {
        if (PII == null) // Si aucune instance de PhysicalInventoryItem n'existe
        {
            PII = this; // Définit cette instance comme l'instance de PhysicalInventoryItem
        }
        else // Si une instance de PhysicalInventoryItem existe déjà
        {
            Debug.Log($"{this.gameObject.name}"); // Affiche un message de débogage avec le nom de l'objet
            this.gameObject.SetActive(false); // Désactive cet objet pour éviter les doublons
        }
        DontDestroyOnLoad(this); // Empêche la destruction de cet objet lors du chargement d'une nouvelle scène
    }

    private void OnTriggerEnter2D(Collider2D collision) // Fonction appelée lorsqu'un objet entre en collision avec le déclencheur de l'élément physique
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger) // Si l'objet entrant en collision est le joueur et n'est pas un déclencheur
        {
            AddItemToInventory(); // Ajoute l'objet à l'inventaire du joueur
            this.gameObject.SetActive(false); // Désactive cet objet physique après l'avoir ramassé
        }
    }

    void AddItemToInventory() // Fonction pour ajouter l'objet à l'inventaire du joueur
    {
        if (playerInventory && thisItem) // Si les références à l'inventaire du joueur et à l'objet InventoryItem existent
        {
            if (playerInventory.myInventory.Contains(thisItem)) // Si l'objet est déjà présent dans l'inventaire du joueur
            {
                thisItem.numberHeld += 1; // Augmente le nombre d'objets tenus de 1
            }
            else // Si l'objet n'est pas encore présent dans l'inventaire du joueur
            {
                playerInventory.myInventory.Add(thisItem); // Ajoute l'objet à l'inventaire du joueur
                thisItem.numberHeld += 1; // Augmente le nombre d'objets tenus de 1
            }
        }
    }
}