using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mesa : MonoBehaviour
{
    [SerializeField]
    GameObject message;
    bool inTable,opened;
    [SerializeField]
    Animator puzzleAnimator;
    // Start is called before the first frame update
    void Start()
    {
        inTable = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.resumeKey)) && inTable)
        {
            if(opened)
            {
                //Fechar o puzzle
                opened = false;
                puzzleAnimator.SetBool("open", false);
            }
            else
            {
                //Abrir o puzzle
                opened = true;
                Debug.Log("Open Puzzle");
                puzzleAnimator.SetBool("open", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            message.SetActive(true);
            inTable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            message.SetActive(false);
            inTable = false;
            if (opened)
            {
                //Fechar o puzzle
                opened = false;
                Debug.Log("Close Puzzle");
                puzzleAnimator.SetBool("open", false);
            }
        }
    }
}
