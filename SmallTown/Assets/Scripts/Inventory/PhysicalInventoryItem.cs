using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    private static PhysicalInventoryItem PII;

    
    private void Awake()
    {
        if (PII == null)
        {
            PII = this;
        }
        else
        {
            Debug.Log($"{this.gameObject.name}");
            this.gameObject.SetActive(false);
        }
        DontDestroyOnLoad(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            AddItemToInventory();
            this.gameObject.SetActive(false);
        }
    }

    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }
}