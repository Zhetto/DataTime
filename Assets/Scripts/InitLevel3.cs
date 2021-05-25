using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitLevel3 : MonoBehaviour
{
    Image image;
    [SerializeField] float force;
    [SerializeField] GameObject[] active;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        image.color -= new Color(0, 0, 0, force);
        if (image.color.a <= 0)
        {
            try { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true; } catch { }
            foreach (var item in active)
            {
                item.SetActive(true);
            }
            Destroy(this);
        }
    }
}
