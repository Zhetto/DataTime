using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]
    float force;
    Vector3 temp;
    public bool maxMin;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!GameController.Pause)
        {
            temp = Vector3.MoveTowards(this.transform.position, playerTransform.transform.position, force);
            this.transform.position = new Vector3(temp.x, temp.y+.3f, -10);
            if (maxMin)
            {
                transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, xMin, xMax), Mathf.Clamp(playerTransform.position.y, yMin, yMax), 2 * playerTransform.position.z);
            }           
        }
    }
}