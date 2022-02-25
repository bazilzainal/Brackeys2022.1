using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] float offset = 2f; 

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(cam.transform.position.x + offset, cam.transform.position.y, cam.transform.position.z + 10f);
    }
}
