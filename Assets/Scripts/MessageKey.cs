using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageKey : MonoBehaviour
{
    [SerializeField]
    Text text;
    [SerializeField]
    LoadControl.Control control;
    [SerializeField]
    string message;
    // Start is called before the first frame update
    void Start()
    {

        text.text = string.Format(message, GameController.getKeyCode(control));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
