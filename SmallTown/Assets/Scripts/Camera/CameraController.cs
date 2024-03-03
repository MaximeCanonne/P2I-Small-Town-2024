using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{

    public Transform Target;

    public float ymin, ymax, xmin, xmax;

    public static CameraController Instance;

    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != Target.position)
        {
            UnityEngine.Vector3 targetPosition = new UnityEngine.Vector3(Target.position.x,
                                                 Target.position.y,
                                                 transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           xmin,
                                           xmax);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                           ymin,
                                           ymax);

            transform.position = UnityEngine.Vector3.Lerp(transform.position,
                                             targetPosition, smoothing);
            //transform.position = Vector3.Lerp(transform.position,
            //                                 targetPosition, smoothing);
        }
    }
}
