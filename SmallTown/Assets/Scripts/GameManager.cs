using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PlayerInput Inputs;

    [HideInInspector]
    public int previousZone;

    private void Awake()
    {
        if (Instance != null && Instance!=this)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }

    public PlayerInput GetInputs()
    {
        return Inputs;
    }
}
