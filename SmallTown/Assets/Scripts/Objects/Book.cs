using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public Signal ContextOn;
    public Signal ContextOff;
    public GameObject dialogBox;
    public Text dialogText;
    public List<string> BeforeQuestDialogs = new List<string>(); // Stocke tous les dialogues d'avant r�alisation de la qu�te
    public List<string> AfterQuestDialogs = new List<string>();
    public string itemName;
    public bool QuestCompleted = false;
    private int currentDialogueIndex = 0; // Pour suivre le dialogue actuel
    public bool playerInRange;
    public PlayerInventory myInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            List<string> dialogs = new List<string>();
            if (!QuestCompleted)
            {
                dialogs = BeforeQuestDialogs;
                bool itemRemoved = myInventory.RemoveItemByName(itemName);
                if (itemRemoved)
                {
                    Debug.Log("Item removed successfully.");
                    QuestCompleted = true;

                }
                else
                {
                    Debug.Log("Item not found in inventory.");
                }
            }
            else
            {
                dialogs = AfterQuestDialogs;
            }
            if (dialogBox.activeInHierarchy)
            {
                // Passe au dialogue suivant
                currentDialogueIndex++;
                if (currentDialogueIndex < dialogs.Count)
                {
                    dialogText.text = dialogs[currentDialogueIndex];
                }
                else
                {
                    // Tous les dialogues ont �t� affich�s, ferme la bo�te de dialogue
                    dialogBox.SetActive(false);
                    // R�initialise l'index pour une prochaine lecture
                    currentDialogueIndex = 0;
                }
            }
            else
            {
                ShowDialogue();
            }
        }
    }

    private void ShowDialogue()
    {
        if (BeforeQuestDialogs.Count > 0)
        {
            dialogBox.SetActive(true);
            dialogText.text = BeforeQuestDialogs[currentDialogueIndex]; // Affiche le premier dialogue
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Si le joueur est dans la zone de collision...
        {
            ContextOn.Raise(); // Le signal "On" est envoy� (Context Clue On)
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ContextOff.Raise(); // Le signal "Off" est envoy� (Context Clue Off)
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

    public void TakeItemFromInventory(string itemName)
    {
        myInventory.RemoveItemByName(itemName);
    }
}
