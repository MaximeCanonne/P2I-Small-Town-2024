using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    public Signal ContextOn; // Signal pour indiquer que le contexte est activé
    public Signal ContextOff; // Signal pour indiquer que le contexte est désactivé
    public GameObject dialogBox; // Référence à la boîte de dialogue
    public Text dialogText; // Référence au composant Text pour afficher le texte de la boîte de dialogue
    public List<string> BeforeQuestDialogs = new List<string>(); // Liste des dialogues avant la réalisation de la quête
    public List<string> AfterQuestDialogs = new List<string>(); // Liste des dialogues après la réalisation de la quête
    public string itemName; // Nom de l'objet associé à l'interaction
    public bool QuestCompleted = false; // Indique si la quête est terminée ou non
    private int currentDialogueIndex = 0; // Index du dialogue actuel
    public bool playerInRange; // Indique si le joueur est dans la zone d'interaction
    public PlayerInventory myInventory; // Référence à l'inventaire du joueur

    // Start is called before the first frame update
    void Start() // Méthode appelée au démarrage
    {
        currentDialogueIndex = 0; // Initialise l'index du dialogue actuel à zéro
    }

    public virtual void Update() // Méthode appelée à chaque frame
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange) // Si la touche E est enfoncée et que le joueur est dans la zone d'interaction
        {
            List<string> dialogs = new List<string>(); // Initialise une nouvelle liste de dialogues
            if (!QuestCompleted) // Si la quête n'est pas terminée
            {
                bool itemRemoved = myInventory.RemoveItemByName(itemName); // Tente de retirer l'objet de l'inventaire du joueur
                if (itemRemoved) // Si l'objet a été retiré avec succès de l'inventaire
                {
                    Debug.Log("Item removed successfully."); // Affiche un message de débogage
                    QuestCompleted = true; // Indique que la quête est terminée
                    dialogs = AfterQuestDialogs; // Utilise les dialogues après la quête
                }
                else // Si l'objet n'a pas été trouvé dans l'inventaire
                {
                    Debug.Log("Item not found in inventory."); // Affiche un message de débogage
                    dialogs = BeforeQuestDialogs; // Utilise les dialogues avant la quête
                }
            }
            else // Si la quête est déjà terminée
            {
                dialogs = AfterQuestDialogs; // Utilise les dialogues après la quête
            }
            if (dialogBox.activeInHierarchy) // Si la boîte de dialogue est déjà active dans la scène
            {
                if (currentDialogueIndex < dialogs.Count - 1) // S'il y a un dialogue suivant
                {
                    currentDialogueIndex++; // Passe au dialogue suivant
                    dialogText.text = dialogs[currentDialogueIndex]; // Affiche le texte du dialogue suivant
                    Debug.Log($"{dialogs[currentDialogueIndex]}"); // Affiche le texte du dialogue suivant dans la console
                }
                else // Si tous les dialogues ont été affichés
                {
                    dialogBox.SetActive(false); // Désactive la boîte de dialogue
                    currentDialogueIndex = 0; // Réinitialise l'index du dialogue actuel pour la prochaine lecture
                }
            }
            else // Si la boîte de dialogue n'est pas active
            {
                ShowDialogue(dialogs); // Affiche la boîte de dialogue avec les dialogues correspondants
            }
        }
    }

    private void ShowDialogue(List<string> dialogs) // Méthode pour afficher la boîte de dialogue avec les dialogues spécifiés
    {
        if (BeforeQuestDialogs.Count > 0) // Si la liste de dialogues avant la quête contient des éléments
        {
            dialogBox.SetActive(true); // Active la boîte de dialogue dans la scène
            dialogText.text = dialogs[currentDialogueIndex]; // Affiche le premier dialogue dans la boîte de dialogue
            currentDialogueIndex = 0; // Réinitialise l'index du dialogue actuel pour afficher le premier dialogue
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Méthode appelée lorsque quelque chose entre en collision avec le déclencheur
    {
        if (collision.CompareTag("Player")) // Si l'objet en collision est le joueur
        {
            ContextOn.Raise(); // Émet le signal pour activer le contexte
            playerInRange = true; // Indique que le joueur est à portée d'interaction
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // Méthode appelée lorsque quelque chose sort de la collision avec le déclencheur
    {
        if (collision.CompareTag("Player")) // Si l'objet en collision est le joueur
        {
            ContextOff.Raise(); // Émet le signal pour désactiver le contexte
            playerInRange = false; // Indique que le joueur n'est plus à portée d'interaction
            dialogBox.SetActive(false); // Désactive la boîte de dialogue
        }
    }

    public void TakeItemFromInventory(string itemName) // Méthode pour retirer un objet de l'inventaire du joueur
    {
        myInventory.RemoveItemByName(itemName); // Retire l'objet spécifié de l'inventaire du joueur
    }
}