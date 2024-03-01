using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PNJ : MonoBehaviour // Dialogues Systems
{
    [SerializeField]
    string[] Sentences;
    [SerializeField]
    string characterName;
    int Index;
    bool isOndial, canDial;

    HUDManager Manager => HUDManager.Instance;

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            StartDialogue();
            Manager.continueButton.GetComponent<Button>().onClick.RemoveAllListeners();
            Manager.continueButton.GetComponent<Button>().onClick.AddListener(delegate { NextLine(); });
        }
    }

    public void StartDialogue()
    {
        Manager.dialogueHolder.SetActive(true);
        CharacterMotor.Instance.canMove = false;
        isOndial = true;
        TypingText(Sentences);
    }

    void TypingText(string[] _sentence)
    {
        Manager.nameDisplay.text = "";
        Manager.textDisplay.text = "";

        Manager.nameDisplay.text = characterName;
        Manager.textDisplay.text = Sentences[Index];

        if (Manager.nameDisplay.text == Sentences[Index])
        {
            Manager.continueButton.SetActive(true);
        }
    }

    public void NextLine()
    {
        Manager.continueButton.SetActive(false);

        if (isOndial && Index < Sentences.Length -1)
        {
            Index++;
            Manager.textDisplay.text = "";
            TypingText(Sentences);
        }
        else if(isOndial && Index == Sentences.Length -1)
        {
            isOndial = false;
            Index = 0;
            Manager.textDisplay.text = "";
            Manager.nameDisplay.text = "";
            Manager.dialogueHolder.SetActive(false);

            CharacterMotor.Instance.canMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
        canDial = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canDial = false;
        }
    }
}
