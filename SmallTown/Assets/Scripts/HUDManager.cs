using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    public GameObject dialogueHolder;
    public TextMeshProUGUI nameDisplay, textDisplay;
    public GameObject continueButton;

    private void Awake()
    {
        Instance = this;
    }
}
