using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_EndZone : MonoBehaviour
{
    public int lastZone;
    [SerializeReference]
    GameObject personnageSupp;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null && CharacterMotor.Instance != null)
        {
            if (lastZone == GameManager.Instance.previousZone)
            {
                CharacterMotor.Instance.transform.position = transform.position;
                //personnageSupp.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
