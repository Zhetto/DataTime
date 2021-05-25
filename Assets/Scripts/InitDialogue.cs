using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDialogue : MonoBehaviour
{
    [SerializeField] DialogueController controller;
    [SerializeField] Dialogue[] Humphrey, Kelley; 
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.playerChoice.name == "Humphrey")
        {
            controller.initial = Humphrey;
        }
        else
        {
            controller.initial = Kelley;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
