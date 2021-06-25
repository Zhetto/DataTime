using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishParticle : MonoBehaviour
{
    [SerializeField] float velocity,maxHeight;
    GameObject player;
    [SerializeField] string scene;
    [SerializeField] GameObject finish;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = player.transform.position + Vector3.up*20;
        maxHeight = this.transform.position.y + 35;
        player.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += Vector3.up * velocity;

        if (this.transform.position.y >= maxHeight)
        {
            if(scene != "")
            {
                SceneManager.LoadScene(scene);
                Destroy(this.gameObject);
            }
            finish.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
