using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velha : MonoBehaviour
{
    [SerializeField] Dialogue[] sentences;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerController.laranjaUsos == 0 && GameObject.FindObjectOfType<PlayerController>().pegouLaranjas == false)
        {
            DialogueController dialogue = GameObject.FindObjectOfType<DialogueController>();
            dialogue.initial = sentences;
            dialogue.StartDialogue();
            PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
            playerController.anim.SetBool("Walk", false);
            PlayerController.laranjaUsos += 3;
            playerController.pegouLaranjas = true;
        }
    }
}
