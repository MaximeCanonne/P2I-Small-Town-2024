using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal; // Signal auquel ce script �coute
    public UnityEvent signalEvent; // �v�nement Unity d�clench� en r�ponse au signal

    public void OnSignalRaised() // M�thode appel�e lorsque le signal est �mis
    {
        signalEvent.Invoke(); // D�clenche l'�v�nement Unity associ�
    }

    private void OnEnable() // M�thode appel�e lorsque le GameObject devient activ�
    {
        signal.RegisterListener(this); // Enregistre ce script comme auditeur du signal
    }

    private void OnDisable() // M�thode appel�e lorsque le GameObject devient d�sactiv�
    {
        signal.DeRegisterListener(this); // D�senregistre ce script comme auditeur du signal
    }
}