using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Camera cam;
    Transform playerTransform;
    [SerializeField] float maxY, minY;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (playerTransform.position.y < maxY && playerTransform.position.y > minY)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, playerTransform.position.y, cam.transform.position.z);
        }
    }
}
