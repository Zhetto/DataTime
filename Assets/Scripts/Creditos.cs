using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int limit;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        txt.rectTransform.localPosition += Vector3.up * speed;
        Debug.Log(txt.rectTransform.localPosition);

        if (txt.rectTransform.localPosition.y >= limit)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
