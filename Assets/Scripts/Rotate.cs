using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    float angle,delayTime,expandForce;
    float time,scaleLimitMax,scaleLimitMin,scale;
    [SerializeField]
    bool right;
    bool expand;
    Vector3 expandAxis;

    // Start is called before the first frame update
    void Start()
    {

        time = Time.time;
        scaleLimitMin = this.transform.localScale.x;
        scaleLimitMax = this.transform.localScale.x * 1.10f;
        
        expandAxis = new Vector3(1 * expandForce, 1 * expandForce, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time < time + delayTime)
        {
            this.transform.Rotate(right ? new Vector3(0,0,1 * angle) : new Vector3(0,0,-1 * angle));
        }
        else
        {
            time = Time.time;
            right = !right;
        }
        if (expand)
        {
            this.transform.localScale += expandAxis;
        }
        else
        {
            this.transform.localScale -= expandAxis;
        }

        if (this.transform.localScale.x > scaleLimitMax)
        {
            expand = false;
        }
        else if(this.transform.localScale.x < scaleLimitMin)
        {
            expand = true;

        }
    }
}
