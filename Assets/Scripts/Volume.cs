using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    Slider sld;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GameObject.FindObjectOfType<AudioSource>();
        sld = this.GetComponent<Slider>();
        sld.value = GameController.Volume;
    }

    public void changed()
    {
        GameController.Volume = sld.value;
        PlayerPrefs.SetFloat("Volume", GameController.Volume);
    }

    private void FixedUpdate()
    {
        sld.value = GameController.Volume;
        aud.volume = GameController.Volume;
    }
}
