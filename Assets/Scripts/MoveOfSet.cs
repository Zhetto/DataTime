using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOfSet : MonoBehaviour
{

    /*--------------------------------------------
	  ----------DECLARAÇÃO DE VARIÁVEIS-----------
	  --------------------------------------------*/

    private Material currentMaterial;
    public float force;
    private Vector3 offset;
    PlayerController playerController;

    /*--------------------------------------------
	  ----------DECLARAÇÃO DE VARIÁVEIS-----------
	  --------------------FIM---------------------*/

    /*--------------------------------------------
	----------------START,UPDATE----------------
	--------------------------------------------*/
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.enabled)
        {
            if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.leftKey)))
            {
                offset = Vector3.right * force;
            }
            else if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.rightKey)))
            {
                offset = Vector3.left * force;
            }
            else
            {
                offset = Vector3.zero;
            }
            this.transform.position += offset;
        }
        
    }    
}
