using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    private float distToPlayer;
    [SerializeField] GameObject player;
    [SerializeField] float followSpeed = 10f;

    [SerializeField] float magDeltaLimit = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(player.transform.position, transform.position);

        // float magDelta = (transform.position - player.transform.position).magnitude;
        if (distToPlayer > magDeltaLimit)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);

        }
    }
}
