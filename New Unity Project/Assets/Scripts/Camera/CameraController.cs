using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Target;

    public float ymin, ymax, xmin, xmax;

    public static CameraController Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 targetPos = Target.transform.position;
        targetPos.z = -10;
        transform.position = new UnityEngine.Vector3(Mathf.Clamp(targetPos.x, xmin, xmax), Mathf.Clamp(targetPos.y, ymin, ymax), targetPos.z);

        //transform.position = targetPos;
    }
}
