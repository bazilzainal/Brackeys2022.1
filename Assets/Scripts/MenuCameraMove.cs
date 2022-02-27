using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraMove : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + cameraSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
