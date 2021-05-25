using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcoWaved : MonoBehaviour
{
    [SerializeField]
    float angle, delayTime;
    float time;
    [SerializeField]
    bool right;

    // Start is called before the first frame update
    void Start()
    {

        time = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time < time + delayTime)
        {
            this.transform.Rotate(right ? new Vector3(0, 0, 1 * angle) : new Vector3(0, 0, -1 * angle));
        }
        else
        {
            time = Time.time;
            right = !right;
        }

    }
}
