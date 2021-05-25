using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] string levelName;
    [SerializeField] Image img;
    Color color;

    private void Start()
    {
        color = new Color(0, 0, 0, force);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (img.color.a < 1)
        {
            img.color += color;
        }
        else
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
