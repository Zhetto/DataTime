using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMap : MonoBehaviour
{
    bool opened;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        opened = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        opened = Input.GetKeyDown(KeyCode.M) ? !opened : opened ;
        if (opened)
        {
            anim.SetBool("open", true);
        }
        else
        {
            anim.SetBool("open", false);
        }
    }
}
