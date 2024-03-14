using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Quest", menuName = "ScriptableObject/Quest", order = 0)]
public class QuestSO : ScriptableObject
{
    public int id;
    public string title;
    public string description;
    public string[] sentences, InprogressSentence, completeSentence;
    public string objectToFind;
    public int actualAmount, amountToFind;

    [System.Serializable]
    public enum Status
    {
        none,
        accept,
        complete
    }

    public Status status;
}
