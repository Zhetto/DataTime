using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleColision : MonoBehaviour
{
    Puzzle puzzleScript;
    CameraController cameraScript;

    private void Start()
    {
        puzzleScript = GetComponent<Puzzle>();
        cameraScript = FindObjectOfType<Camera>().GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {       
            puzzleScript.enabled = true;
            puzzleScript.show = true;
            cameraScript.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            puzzleScript.show = false;    
        }
    }
}
