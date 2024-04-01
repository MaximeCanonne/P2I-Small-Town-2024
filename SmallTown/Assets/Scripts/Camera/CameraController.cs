using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{

    public Transform Target; // Cible sur laquelle centrer la caméra

    public float ymin, ymax, xmin, xmax; // Dimensions (2D) max/min pour la caméra

    public static CameraController Instance; // Instance de la caméra

    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != Target.position) // Si la position de la caméra n'est pas centrée sur sa cible alors le script suivant est lancé :
        {
            UnityEngine.Vector3 targetPosition = new UnityEngine.Vector3(Target.position.x,
                                                 Target.position.y,
                                                 transform.position.z); // Récupération des coordonnées du joueur
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           xmin,
                                           xmax);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                           ymin,
                                           ymax); // targetPosition est instancié si les positions récupérées rentrent dans l'intervalle défini (= position max/min de la caméra)

            transform.position = UnityEngine.Vector3.Lerp(transform.position,
                                             targetPosition, smoothing); // Translation de la caméra, modulée par la variable "smoothing"
        }
    }
}
