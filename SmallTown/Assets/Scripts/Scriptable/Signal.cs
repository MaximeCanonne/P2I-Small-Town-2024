using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // Attribut pour créer un nouvel objet dans le menu contextuel
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>(); // Liste des auditeurs du signal

    public void Raise() // Méthode pour émettre le signal
    {
        for (int i = listeners.Count - 1; i >= 0; i--) // Parcours la liste des auditeurs en commençant par la fin
        {
            listeners[i].OnSignalRaised(); // Appelle la méthode OnSignalRaised() de chaque auditeur
        }
    }

    public void RegisterListener(SignalListener listener) // Méthode pour enregistrer un auditeur
    {
        listeners.Add(listener); // Ajoute l'auditeur à la liste des auditeurs
    }

    public void DeRegisterListener(SignalListener listener) // Méthode pour désenregistrer un auditeur
    {
        listeners.Remove(listener); // Supprime l'auditeur de la liste des auditeurs
    }
}