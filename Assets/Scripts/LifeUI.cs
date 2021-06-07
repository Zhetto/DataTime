using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = Checkpoint.restLife.ToString();    
    }
}
