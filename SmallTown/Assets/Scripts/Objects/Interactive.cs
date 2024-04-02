using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    public Signal ContextOn; // Signal pour indiquer que le contexte est activ�
    public Signal ContextOff; // Signal pour indiquer que le contexte est d�sactiv�
    public GameObject dialogBox; // R�f�rence � la bo�te de dialogue
    public Text dialogText; // R�f�rence au composant Text pour afficher le texte de la bo�te de dialogue
    public List<string> BeforeQuestDialogs = new List<string>(); // Liste des dialogues avant la r�alisation de la qu�te
    public List<string> AfterQuestDialogs = new List<string>(); // Liste des dialogues apr�s la r�alisation de la qu�te
    public string itemName; // Nom de l'objet associ� � l'interaction
    public bool QuestCompleted = false; // Indique si la qu�te est termin�e ou non
    private int currentDialogueIndex = 0; // Index du dialogue actuel
    public bool playerInRange; // Indique si le joueur est dans la zone d'interaction
    public PlayerInventory myInventory; // R�f�rence � l'inventaire du joueur

    // Start is called before the first frame update
    void Start() // M�thode appel�e au d�marrage
    {
        currentDialogueIndex = 0; // Initialise l'index du dialogue actuel � z�ro
    }

    public virtual void Update() // M�thode appel�e � chaque frame
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange) // Si la touche E est enfonc�e et que le joueur est dans la zone d'interaction
        {
            List<string> dialogs = new List<string>(); // Initialise une nouvelle liste de dialogues
            if (!QuestCompleted) // Si la qu�te n'est pas termin�e
            {
                bool itemRemoved = myInventory.RemoveItemByName(itemName); // Tente de retirer l'objet de l'inventaire du joueur
                if (itemRemoved) // Si l'objet a �t� retir� avec succ�s de l'inventaire
                {
                    Debug.Log("Item removed successfully."); // Affiche un message de d�bogage
                    QuestCompleted = true; // Indique que la qu�te est termin�e
                    dialogs = AfterQuestDialogs; // Utilise les dialogues apr�s la qu�te
                }
                else // Si l'objet n'a pas �t� trouv� dans l'inventaire
                {
                    Debug.Log("Item not found in inventory."); // Affiche un message de d�bogage
                    dialogs = BeforeQuestDialogs; // Utilise les dialogues avant la qu�te
                }
            }
            else // Si la qu�te est d�j� termin�e
            {
                dialogs = AfterQuestDialogs; // Utilise les dialogues apr�s la qu�te
            }
            if (dialogBox.activeInHierarchy) // Si la bo�te de dialogue est d�j� active dans la sc�ne
            {
                if (currentDialogueIndex < dialogs.Count - 1) // S'il y a un dialogue suivant
                {
                    currentDialogueIndex++; // Passe au dialogue suivant
                    dialogText.text = dialogs[currentDialogueIndex]; // Affiche le texte du dialogue suivant
                    Debug.Log($"{dialogs[currentDialogueIndex]}"); // Affiche le texte du dialogue suivant dans la console
                }
                else // Si tous les dialogues ont �t� affich�s
                {
                    dialogBox.SetActive(false); // D�sactive la bo�te de dialogue
                    currentDialogueIndex = 0; // R�initialise l'index du dialogue actuel pour la prochaine lecture
                }
            }
            else // Si la bo�te de dialogue n'est pas active
            {
                ShowDialogue(dialogs); // Affiche la bo�te de dialogue avec les dialogues correspondants
            }
        }
    }

    private void ShowDialogue(List<string> dialogs) // M�thode pour afficher la bo�te de dialogue avec les dialogues sp�cifi�s
    {
        if (BeforeQuestDialogs.Count > 0) // Si la liste de dialogues avant la qu�te contient des �l�ments
        {
            dialogBox.SetActive(true); // Active la bo�te de dialogue dans la sc�ne
            dialogText.text = dialogs[currentDialogueIndex]; // Affiche le premier dialogue dans la bo�te de dialogue
            currentDialogueIndex = 0; // R�initialise l'index du dialogue actuel pour afficher le premier dialogue
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // M�thode appel�e lorsque quelque chose entre en collision avec le d�clencheur
    {
        if (collision.CompareTag("Player")) // Si l'objet en collision est le joueur
        {
            ContextOn.Raise(); // �met le signal pour activer le contexte
            playerInRange = true; // Indique que le joueur est � port�e d'interaction
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // M�thode appel�e lorsque quelque chose sort de la collision avec le d�clencheur
    {
        if (collision.CompareTag("Player")) // Si l'objet en collision est le joueur
        {
            ContextOff.Raise(); // �met le signal pour d�sactiver le contexte
            playerInRange = false; // Indique que le joueur n'est plus � port�e d'interaction
            dialogBox.SetActive(false); // D�sactive la bo�te de dialogue
        }
    }

    public void TakeItemFromInventory(string itemName) // M�thode pour retirer un objet de l'inventaire du joueur
    {
        myInventory.RemoveItemByName(itemName); // Retire l'objet sp�cifi� de l'inventaire du joueur
    }
}