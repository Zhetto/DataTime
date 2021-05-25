using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerJ : MonoBehaviour
{
    public float speed = 0.15f;
    private Transform target;

    public bool maxMin;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    void Start()
    {

    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed) + new Vector3(0, 0.4f, target.position.z);

            if (maxMin)
            {
                transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), 2 * target.position.z);
            }
        }
    }
}
