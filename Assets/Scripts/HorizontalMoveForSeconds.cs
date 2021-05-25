using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMoveForSeconds : MonoBehaviour
{
    [SerializeField]
    float force,delay;
    Vector3 partialMovement;
    [SerializeField]
    bool right;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        partialMovement = new Vector3(force, 0, 0);
        time = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time >= time + delay)
        {
            time = Time.time;
            right = !right;
        }

        if (right)
        {
            this.transform.position += partialMovement;
        }
        else
        {
            this.transform.position -= partialMovement;
        }
    }
}
