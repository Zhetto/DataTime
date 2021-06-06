using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mesa : MonoBehaviour
{
    [SerializeField]
    GameObject message,Mira;
    bool inTable,opened;
    [SerializeField]
    Animator puzzleAnimator;
    // Start is called before the first frame update
    void Start()
    {
        inTable = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTable)
        {
            if(opened)
            {
                //Fechar o puzzle
                opened = false;
                puzzleAnimator.SetBool("open", false);
                Cursor.visible = false;
                Mira.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
            }
            else
            {
                //Abrir o puzzle
                opened = true;
                Debug.Log("Open Puzzle");
                puzzleAnimator.SetBool("open", true);
                Cursor.visible = true;
                Mira.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
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
