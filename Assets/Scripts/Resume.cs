using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(GameController.KeyResume))
        {
            this.gameObject.SetActive(false);
        }
    }
}
