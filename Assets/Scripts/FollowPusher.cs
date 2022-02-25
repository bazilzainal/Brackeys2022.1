using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPusher : MonoBehaviour
{
    [SerializeField] GameObject pusher;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < pusher.transform.position.x)
        {
            transform.position = new Vector3(pusher.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
