using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitFase1 : MonoBehaviour
{
    float time;
    [SerializeField]
    float secondsDelay;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        secondsDelay = secondsDelay == 0 ? 2 : secondsDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
