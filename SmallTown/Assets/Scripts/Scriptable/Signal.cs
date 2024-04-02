using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // Attribut pour cr�er un nouvel objet dans le menu contextuel
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>(); // Liste des auditeurs du signal

    public void Raise() // M�thode pour �mettre le signal
    {
        for (int i = listeners.Count - 1; i >= 0; i--) // Parcours la liste des auditeurs en commen�ant par la fin
        {
            listeners[i].OnSignalRaised(); // Appelle la m�thode OnSignalRaised() de chaque auditeur
        }
    }

    public void RegisterListener(SignalListener listener) // M�thode pour enregistrer un auditeur
    {
        listeners.Add(listener); // Ajoute l'auditeur � la liste des auditeurs
    }

    public void DeRegisterListener(SignalListener listener) // M�thode pour d�senregistrer un auditeur
    {
        listeners.Remove(listener); // Supprime l'auditeur de la liste des auditeurs
    }
}