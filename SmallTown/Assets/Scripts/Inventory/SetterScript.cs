using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject InventoryMenu;
    private bool menuActivated;

    void Update()
    {
        if (Input.GetButtonDown("inventory") && menuActivated)
        {
            menuActivated = false;
            InventoryMenu.SetActive(false);
            // Debug.Log("Inventory_Test_Close");
        }
        else if (Input.GetButtonDown("inventory") && !menuActivated)
        {
            menuActivated = true;
            InventoryMenu.SetActive(true);
            // Debug.Log("Inventory_Test_Open");
        }
    }
}
