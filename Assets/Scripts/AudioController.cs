using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class AudioController : MonoBehaviour
{
    public static AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = GameController.Volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}
