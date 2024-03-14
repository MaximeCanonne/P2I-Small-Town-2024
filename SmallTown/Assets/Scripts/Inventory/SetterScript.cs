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
            Debug.Log("bahahaha");
        }
        else if (Input.GetButtonDown("inventory") && !menuActivated)
        {
            menuActivated = true;
            InventoryMenu.SetActive(true);
            Debug.Log("Bouhouhouhou");
        }
    }
}
