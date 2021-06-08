using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaController : MonoBehaviour
{
    public Animator anim;
    public AudioSource ambiente;
    public AudioSource boss;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (Checkpoint.checkPointBoss)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position += Vector3.down * 12;
            GameObject.FindGameObjectWithTag("Player").transform.position += Vector3.left * 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ambiente.Stop();
            boss.Play();
            anim.SetTrigger("Fechar");
            Checkpoint.checkPointBoss = true;
            PlayerPrefs.SetInt("checkPointBoss", 1);
        }
    }
}
