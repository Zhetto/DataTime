using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSea : MonoBehaviour
{
    [SerializeField]
    float force, delayTime;
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
            this.transform.position += right ? Vector3.right* force : Vector3.left * force;
        }
        else
        {
            time = Time.time;
            right = !right;
        }
    }
}
