using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadControl : MonoBehaviour
{
    Text text;
    [SerializeField]
    public Control control;
    public enum Control 
    {
        upKey,
        downKey,
        rightKey,
        leftKey,
        pauseKey,
        resumeKey
    }

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        switch (control)
        {
            case Control.upKey:
                text.text = GameController.KeyUp.ToString();
                break;
            case Control.downKey:
                text.text = GameController.KeyDown.ToString();
                break;
            case Control.rightKey:
                text.text = GameController.KeyRight.ToString();
                break;
            case Control.leftKey:
                text.text = GameController.KeyLeft.ToString();
                break;
            case Control.pauseKey:
                text.text = GameController.KeyPause.ToString();
                break;
            case Control.resumeKey:
                text.text = GameController.KeyResume.ToString();
                break;
        }
    }
}
