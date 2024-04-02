using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal; // Signal auquel ce script écoute
    public UnityEvent signalEvent; // Événement Unity déclenché en réponse au signal

    public void OnSignalRaised() // Méthode appelée lorsque le signal est émis
    {
        signalEvent.Invoke(); // Déclenche l'événement Unity associé
    }

    private void OnEnable() // Méthode appelée lorsque le GameObject devient activé
    {
        signal.RegisterListener(this); // Enregistre ce script comme auditeur du signal
    }

    private void OnDisable() // Méthode appelée lorsque le GameObject devient désactivé
    {
        signal.DeRegisterListener(this); // Désenregistre ce script comme auditeur du signal
    }
}