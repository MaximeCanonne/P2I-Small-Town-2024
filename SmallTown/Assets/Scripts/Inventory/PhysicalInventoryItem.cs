using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory; // R�f�rence s�rialis�e vers le script PlayerInventory
    [SerializeField] private InventoryItem thisItem; // R�f�rence s�rialis�e vers l'objet InventoryItem de cet �l�ment physique
    private static PhysicalInventoryItem PII; // Instance statique de PhysicalInventoryItem

    private void Awake() // Fonction appel�e au r�veil de l'objet, pour sauvegarder les donn�es de l'inventaire lors du passage d'une sc�ne � l'autre.
    {
        if (PII == null) // Si aucune instance de PhysicalInventoryItem n'existe
        {
            PII = this; // D�finit cette instance comme l'instance de PhysicalInventoryItem
        }
        else // Si une instance de PhysicalInventoryItem existe d�j�
        {
            Debug.Log($"{this.gameObject.name}"); // Affiche un message de d�bogage avec le nom de l'objet
            this.gameObject.SetActive(false); // D�sactive cet objet pour �viter les doublons
        }
        DontDestroyOnLoad(this); // Emp�che la destruction de cet objet lors du chargement d'une nouvelle sc�ne
    }

    private void OnTriggerEnter2D(Collider2D collision) // Fonction appel�e lorsqu'un objet entre en collision avec le d�clencheur de l'�l�ment physique
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger) // Si l'objet entrant en collision est le joueur et n'est pas un d�clencheur
        {
            AddItemToInventory(); // Ajoute l'objet � l'inventaire du joueur
            this.gameObject.SetActive(false); // D�sactive cet objet physique apr�s l'avoir ramass�
        }
    }

    void AddItemToInventory() // Fonction pour ajouter l'objet � l'inventaire du joueur
    {
        if (playerInventory && thisItem) // Si les r�f�rences � l'inventaire du joueur et � l'objet InventoryItem existent
        {
            if (playerInventory.myInventory.Contains(thisItem)) // Si l'objet est d�j� pr�sent dans l'inventaire du joueur
            {
                thisItem.numberHeld += 1; // Augmente le nombre d'objets tenus de 1
            }
            else // Si l'objet n'est pas encore pr�sent dans l'inventaire du joueur
            {
                playerInventory.myInventory.Add(thisItem); // Ajoute l'objet � l'inventaire du joueur
                thisItem.numberHeld += 1; // Augmente le nombre d'objets tenus de 1
            }
        }
    }
}