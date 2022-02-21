using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float followSpeed = 0.02f;

    [SerializeField] float magDeltaLimit = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float magDelta = (transform.position - player.transform.position).magnitude;
        if (magDelta > magDeltaLimit)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed);

        }
    }
}
