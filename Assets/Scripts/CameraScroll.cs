using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{

    private float scrollSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.right * scrollSpeed;
        transform.position = new Vector3(transform.position.x * scrollSpeed, transform.position.y, transform.position.z);
    }
}
