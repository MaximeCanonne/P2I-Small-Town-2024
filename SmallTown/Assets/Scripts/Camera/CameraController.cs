using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{

    public Transform Target; // Cible sur laquelle centrer la cam�ra

    public float ymin, ymax, xmin, xmax; // Dimensions (2D) max/min pour la cam�ra

    public static CameraController Instance; // Instance de la cam�ra

    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != Target.position) // Si la position de la cam�ra n'est pas centr�e sur sa cible alors le script suivant est lanc� :
        {
            UnityEngine.Vector3 targetPosition = new UnityEngine.Vector3(Target.position.x,
                                                 Target.position.y,
                                                 transform.position.z); // R�cup�ration des coordonn�es du joueur
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           xmin,
                                           xmax);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                           ymin,
                                           ymax); // targetPosition est instanci� si les positions r�cup�r�es rentrent dans l'intervalle d�fini (= position max/min de la cam�ra)

            transform.position = UnityEngine.Vector3.Lerp(transform.position,
                                             targetPosition, smoothing); // Translation de la cam�ra, modul�e par la variable "smoothing"
        }
    }
}
