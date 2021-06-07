using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue 
{
    [TextArea(10,15)]
    public string sentences;
    public string name;
    public Sprite sprite;
}
