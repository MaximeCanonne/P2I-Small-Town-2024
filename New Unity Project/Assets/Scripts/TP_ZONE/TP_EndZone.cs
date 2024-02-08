using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_EndZone : MonoBehaviour
{
    public string lastZone;
    // Start is called before the first frame update
    void Start()
    {
        if (lastZone == GameManager.Instance.previousZone)
        {
            CharacterMotor.Instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
