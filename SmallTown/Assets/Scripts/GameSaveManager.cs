using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    private static GameSaveManager gameSave;
    public List<ScriptableObject> objects = new List<ScriptableObject>();

    private void Awake()
    {
        if (gameSave == null)
        {
            gameSave = this;
        }
        else
        {
            Debug.Log($"{this.gameObject.name}");
            this.gameObject.SetActive(false);
        }
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}