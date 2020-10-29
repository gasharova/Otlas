using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeleteOutOfCamera : MonoBehaviour
{
    //public GameObject cameraView;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Camera.main.transform.position.x - 20 > transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
