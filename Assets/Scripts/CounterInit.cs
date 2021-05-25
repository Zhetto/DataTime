using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterInit : MonoBehaviour
{
    Text text;
    float time;
    [SerializeField]
    string messageInit;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {       

        if (text.text == "0")
        {
            GameController.TimeInit = -1;
            time = Time.time+1;
            text.text = messageInit;            
        }else if(text.text != messageInit)
        {
            text.text = GameController.TimeInit.ToString();
        }
        if (Time.time > time && text.text == messageInit)
        {
            Destroy(this.gameObject);
        }
    }
}
