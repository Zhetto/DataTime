using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    bool alterKey;
    GameObject obj;

    public void openObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void closeObject(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void detectKey()
    {
        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text = "Pressione uma tecla";
        alterKey = true;
        obj = new GameObject();
    }
    public void disableResume(GameObject obj)
    {
        obj.GetComponent<Resume>().enabled = false;
    }

    private void OnGUI()
    {
        if (alterKey)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                obj = EventSystem.current.currentSelectedGameObject;
                //obj.GetComponent<Resume>().enabled = false;
                switch (obj.GetComponent<LoadControl>().control)
                {
                    case LoadControl.Control.upKey:
                        GameController.KeyUp = e.keyCode;
                        break;
                    case LoadControl.Control.downKey:
                        GameController.KeyDown = e.keyCode;
                        break;
                    case LoadControl.Control.rightKey:
                        GameController.KeyRight = e.keyCode;
                        break;
                    case LoadControl.Control.leftKey:
                        GameController.KeyLeft = e.keyCode;
                        break;
                    case LoadControl.Control.pauseKey:
                        GameController.KeyPause = e.keyCode;
                        break;
                    case LoadControl.Control.resumeKey:
                        GameController.KeyResume = e.keyCode;
                        break;
                }
                alterKey = false;
                obj.GetComponentInChildren<Text>().text = e.keyCode.ToString();
                GameController.Save();
            }
            obj.GetComponent<Resume>().enabled = true;
        }
    }
}
