using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] Image filled;
    [SerializeField] float force;
    // Start is called before the first frame update
    void Start()
    {
        force = force == 0 ? .01f : force ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float result = (float)PlayerController.life / 10;
        //Debug.Log(result);
        if (filled.fillAmount != result)
        {
            if (result > filled.fillAmount)
            {
                filled.fillAmount += force;
            }
            if (result < filled.fillAmount)
            {
                filled.fillAmount -= force;
            }
        }
    }
}
